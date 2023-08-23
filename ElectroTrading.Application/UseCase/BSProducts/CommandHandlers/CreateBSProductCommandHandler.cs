using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.BSProducts.Commands;
using ElectroTrading.Application.UseCase.Storages.Commands;
using ElectroTrading.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.BSProducts.CommandHandlers
{
    public class CreateBSProductCommandHandler : ICommandHandler<CreateBSProductCommand, BSProductViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISendTelegramMessage _sendMsg;
        private readonly IMediator _mediator;
        public CreateBSProductCommandHandler(IAppDbContext context, IMapper mapper, ISendTelegramMessage sendMsg, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _sendMsg = sendMsg;
            _mediator = mediator;
        }

        public async Task<BSProductViewModel> Handle(CreateBSProductCommand request, CancellationToken cancellationToken)
        {
            var bsProduct = _mapper.Map<BoughtAndSoldProduct>(request);
            bsProduct.CreatedDate = DateTime.SpecifyKind(DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(5)).DateTime, DateTimeKind.Utc).ToUniversalTime();

            await _context.BoughtAndSoldsProducts.AddAsync(bsProduct, cancellationToken);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
                else
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }

            var viewModel = _mapper.Map<BSProductViewModel>(bsProduct);
            viewModel.Product = _mapper.Map<ProductViewModel>(await _context.Products.FirstOrDefaultAsync(x => x.Id == bsProduct.ProductId, cancellationToken));
            viewModel.Price = request.Price;
            viewModel.Amount = request.Amount;
            viewModel.Avans = request.Avans;
            viewModel.TotalPrice = Convert.ToDecimal(viewModel.Amount) * viewModel.Price;

            if (request.Category == Domain.Enum.CategoryProcess.Bought)
            {
                try
                {
                    AddProductStorageCommand command = new AddProductStorageCommand();
                    command.ProductId = bsProduct.ProductId;
                    command.Amount = bsProduct.Amount;

                    await _mediator.Send(command, cancellationToken);
                }
                catch { }
            }
            else
            {
                try
                {
                    var fp = await _context.FinishedProducts.FirstOrDefaultAsync(x => x.ProductId == bsProduct.ProductId, cancellationToken);
                    var st = await _context.Storages.Include(x => x.Product).ThenInclude(t => t.Compositions).FirstOrDefaultAsync(x => x.ProductId == bsProduct.ProductId, cancellationToken);
                    if (fp != null && fp.Amount >= bsProduct.Amount)
                    {
                        fp.Amount = fp.Amount - bsProduct.Amount;
                    }

                    if (bsProduct?.Product != null && bsProduct.Product.Compositions != null)
                    {
                        foreach (var comp in bsProduct.Product.Compositions)
                        {
                            var removest = await _context.Storages.FirstOrDefaultAsync(x => x.ProductId == comp.ProductId, cancellationToken);
                            if (removest == null)
                            {
                                continue;
                            }
                            removest.Amount = removest.Amount - comp.Amount;
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                
                try
                {
                    await _context.SaveChangesAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                    }
                    else
                    {
                        Console.WriteLine("Exception: " + ex.Message);
                    }
                }
            }

            try
            {
                await _sendMsg.SendMessage(await _sendMsg.MakeBSProductText(viewModel));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message.ToString());
            }

            return viewModel;
        }
    }
}
