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
        public CreateBSProductCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BSProductViewModel> Handle(CreateBSProductCommand request, CancellationToken cancellationToken)
        {
            var bsProduct = _mapper.Map<BoughtAndSoldProduct>(request);
            bsProduct.CreatedDate = DateTime.UtcNow;

            await _context.BoughtAndSoldsProducts.AddAsync(bsProduct, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            
            return _mapper.Map<BSProductViewModel>(bsProduct);
        }
    }
}
