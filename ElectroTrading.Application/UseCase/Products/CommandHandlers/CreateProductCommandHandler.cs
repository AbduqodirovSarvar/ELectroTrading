using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Products.Commands;
using ElectroTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Products.CommandHandlers
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ProductViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductViewModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Name == request.Name, cancellationToken);
            if (product != null)
            {
                throw new AlreadyExistsException();
            }

            Product createModel = _mapper.Map<Product>(request);
            createModel.CreatedDate= DateTime.UtcNow;

            await _context.Products.AddAsync(createModel, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ProductViewModel>(createModel);
        }
    }
}
