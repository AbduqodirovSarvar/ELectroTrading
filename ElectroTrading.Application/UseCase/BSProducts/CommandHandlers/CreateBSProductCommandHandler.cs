using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.BSProducts.Commands;
using ElectroTrading.Domain.Entities;
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
        public CreateBSProductCommandHandler(IAppDbContext context, IMapper mapper, ISendTelegramMessage sendMsg)
        {
            _context = context;
            _mapper = mapper;
            _sendMsg = sendMsg;
        }

        public async Task<BSProductViewModel> Handle(CreateBSProductCommand request, CancellationToken cancellationToken)
        {
            var bsProduct = _mapper.Map<BoughtAndSoldProduct>(request);
            bsProduct.CreatedDate = DateTime.UtcNow;

            await _context.BoughtAndSoldsProducts.AddAsync(bsProduct, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var viewModel = _mapper.Map<BSProductViewModel>(bsProduct);
            viewModel.Product = _mapper.Map<ProductViewModel>(await _context.Products.FirstOrDefaultAsync(x => x.Id == bsProduct.ProductId, cancellationToken));
            viewModel.Price = request.Price;
            viewModel.Amount = request.Amount;
            viewModel.TotalPrice = Convert.ToDecimal(viewModel.Amount) * viewModel.Price;


            await _sendMsg.SendMessage(await _sendMsg.MakeBSProductText(viewModel));

            return viewModel;
        }
    }
}
