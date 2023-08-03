using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.FinishedProducts.Commands;
using ElectroTrading.Application.UseCase.Products.Commands;
using ElectroTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.FinishedProducts.CommandHandlers
{
    public class CreateFinishedProductCommandHandler : ICommandHandler<CreateFinishedProductCommand, FinishedProductViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public CreateFinishedProductCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FinishedProductViewModel> Handle(CreateFinishedProductCommand request, CancellationToken cancellationToken)
        {
            var finishedProduct = await _context.FinishedProducts.Include(x => x.Product).FirstOrDefaultAsync(x => x.ProductId == request.ProductId, cancellationToken);
            FinishedProductViewModel viewModel;
            if (finishedProduct != null)
            {
                finishedProduct.Amount = finishedProduct.Amount + request.Amount;
                await _context.SaveChangesAsync(cancellationToken);
                viewModel = _mapper.Map<FinishedProductViewModel>(finishedProduct);
                viewModel.Product = _mapper.Map<ProductViewModel>(finishedProduct.Product);
            }
            else
            {
                FinishedProduct createModel = _mapper.Map<FinishedProduct>(request);
                createModel.CreatedDate = DateTime.UtcNow;
                await _context.FinishedProducts.AddAsync(createModel, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                viewModel = _mapper.Map<FinishedProductViewModel>(createModel);
                viewModel.Product = _mapper.Map<ProductViewModel>(await _context.Products.FirstOrDefaultAsync(x => x.Id == createModel.ProductId, cancellationToken));
            }

            return viewModel;
        }
    }
}
