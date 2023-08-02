using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.BSProducts.Commands;
using ElectroTrading.Domain.Entities;
using ElectroTrading.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.BSProducts.CommandHandlers
{
    public class UpdateBSProductCommandHandler : ICommandHandler<UpdateBSProductCommand, BSProductViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public UpdateBSProductCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BSProductViewModel> Handle(UpdateBSProductCommand request, CancellationToken cancellationToken)
        {
            var bsProduct = await _context.BoughtAndSoldsProducts.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (bsProduct == null)
                throw new NotFoundException();

            bsProduct.Description = request?.Description ?? bsProduct.Description;
            bsProduct.Price = request?.Price ?? bsProduct.Price;
            bsProduct.Amount = request?.Amount ?? bsProduct.Amount;

            await _context.SaveChangesAsync(cancellationToken);
            var viewModel = _mapper.Map<BSProductViewModel>(bsProduct);
            viewModel.Product = _mapper.Map<ProductViewModel>(bsProduct.Product);

            return viewModel;
        }
    }
}
