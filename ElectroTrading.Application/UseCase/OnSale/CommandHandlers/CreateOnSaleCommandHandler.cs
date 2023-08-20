using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.OnSale.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.OnSale.CommandHandlers
{
    public class CreateOnSaleCommandHandler : ICommandHandler<CreateOnSaleCommand, ProductViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public CreateOnSaleCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(CreateOnSaleCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Include(x => x.Compositions).ThenInclude(x => x.Composition).FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException();
            }

            product.IsOnSale = true;

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
            viewModel.Compositions = _mapper.Map<List<ProductCompositionViewModel>>(product.Compositions).OrderByDescending(x => x.CompositionId).ToList();
            
            return viewModel; 
        }
    }
}
