using AutoMapper;
using ElectroTrading.Application.Abstractions;
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
    public class GetAllProductByFilterQueryHandler : IQueryHandler<GetAllProductByFilterQuery, List<ProductViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllProductByFilterQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductViewModel>> Handle(GetAllProductByFilterQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.Include(x => x.Compositions).ToListAsync(cancellationToken);

            if (request?.Category != null)
            {
                products = products.Where(x => x.Category == request.Category).ToList();
            }

            if(request?.isFinished != null)
            {
                if(request.isFinished == true)
                {
                    products = products.Where(x => _context.FinishedProducts.Any(fp => fp.ProductId == x.Id)).ToList();
                }
                else
                {
                    products = products.Where(x => _context.FinishedProducts.Any(fp => fp.ProductId != x.Id)).ToList();
                    products = (from x in products
                                join fp in _context.FinishedProducts on x.Id  !equals fp.Id
                                select x).ToList();
                }
            }

            List<ProductViewModel> result = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var viewModel = _mapper.Map<ProductViewModel>(product);
                viewModel.Compositions = _mapper.Map<List<ProductCompositionViewModel>>(product.Compositions);
                result.Add(viewModel);
            }
            
            return result;
        }
    }
}
