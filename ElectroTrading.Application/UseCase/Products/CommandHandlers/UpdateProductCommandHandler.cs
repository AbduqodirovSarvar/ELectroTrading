using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Products.Commands;
using ElectroTrading.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Products.CommandHandlers
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, ProductViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Include(x => x.Compositions).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException();
            }

            product.Name = request?.Name ?? product.Name;
            product.Description = request?.Description ?? product.Description;
            product.Price = request?.Price ?? product.Price;
            product.Category = request?.Category ?? product.Category;

            if (request?.Compositions != null)
            {
                foreach(var composition in request.Compositions)
                {
                    var comp = product.Compositions.FirstOrDefault(x => x.CompositionId == composition.CompositionId);
                    if (comp == null)
                        continue;

                    comp.Amount = composition?.Amount ?? comp.Amount;
                }
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

            var viewModel = _mapper.Map<ProductViewModel>(product);
            viewModel.Compositions = _mapper.Map<List<ProductCompositionViewModel>>(product.Compositions);
            
            return viewModel;
        }
    }
}
