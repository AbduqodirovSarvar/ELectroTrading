using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Storages.Commands;
using ElectroTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Storages.CommandHandlers
{
    public class AddProductStorageCommandHandler : ICommandHandler<AddProductStorageCommand, StorageViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public AddProductStorageCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StorageViewModel> Handle(AddProductStorageCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Storages.Include(x => x.Product).FirstOrDefaultAsync(x => x.ProductId == request.ProductId);
            StorageViewModel viewModel;
            if (product == null)
            {
                var st = _mapper.Map<Storage>(request);
                st.CreatedDate = DateTime.UtcNow;

                viewModel = _mapper.Map<StorageViewModel>(request);
                viewModel.Product = _mapper.Map<ProductViewModel>(await _context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken));

                await _context.Storages.AddAsync(st, cancellationToken); 
            }
            else
            {
                product.Amount = product.Amount + request.Amount;
                viewModel = _mapper.Map<StorageViewModel>(product);
                viewModel.Product = _mapper.Map<ProductViewModel>(product.Product);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return viewModel;
        }
    }
}
