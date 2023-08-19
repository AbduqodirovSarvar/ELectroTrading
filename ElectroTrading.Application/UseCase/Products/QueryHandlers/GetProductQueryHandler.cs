using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Products.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Products.QueryHandlers
{
    public class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetProductQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Include(x => x.Compositions).ThenInclude(x => x.Composition).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException();
            }

            var viewModel = _mapper.Map<ProductViewModel>(product);
            viewModel.Compositions = _mapper.Map<List<ProductCompositionViewModel>>(product.Compositions);

            return viewModel;
        }
    }
}
