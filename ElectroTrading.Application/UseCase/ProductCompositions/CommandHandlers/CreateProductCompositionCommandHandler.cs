using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.ProductCompositions.Commands;
using ElectroTrading.Application.UseCase.Products.Commands;
using ElectroTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.ProductCompositions.CommandHandlers
{
    public class CreateProductCompositionCommandHandler : ICommandHandler<CreateProductCompositionCommand, ProductViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public CreateProductCompositionCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(CreateProductCompositionCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Include(x => x.Compositions).ThenInclude(x => x.Composition).FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException("Product Not found");
            }

            ProductViewModel viewModel = _mapper.Map<ProductViewModel>(product);

            foreach (var comp in request.CompositionIds)
            {
                var composition = product.Compositions.FirstOrDefault(x => x.CompositionId == comp.CompositionId);
                if (composition == null)
                {
                    ProductComposition createModel = _mapper.Map<ProductComposition>(comp);
                    createModel.ProductId = request.ProductId;

                    await _context.ProductCompositions.AddAsync(createModel, cancellationToken);
/*
                    viewModel.Compositions.Add(_mapper.Map<ProductCompositionViewModel>(createModel));*/
                }
                else
                {
                    composition.Amount = composition.Amount + comp.Amount;

                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            viewModel.Compositions = _mapper.Map<List<ProductCompositionViewModel>>(product.Compositions);

            return viewModel;
        }
    }
}
