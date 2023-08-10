using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.BSProducts.Queries;
using ElectroTrading.Application.UseCase.Products.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.BSProducts.QueryHandlers
{
    public class GetAllBSProductByFilterQueryHandler : IQueryHandler<GetAllBSProductByFilterQuery, List<BSProductViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllBSProductByFilterQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BSProductViewModel>> Handle(GetAllBSProductByFilterQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.BoughtAndSoldsProducts.Include(x => x.Product).ToListAsync(cancellationToken);

            if (request?.ProductId != null)
            {
                products = products.Where(x => x.ProductId == request.ProductId).ToList();
            }

            if (request?.Category != null)
            {
                products = products.Where(x => x.Category == request.Category).ToList();
            }

            var viewModel = new List<BSProductViewModel>();
            foreach (var product in products)
            {
                var view = _mapper.Map<BSProductViewModel>(product);
                view.Product = _mapper.Map<ProductViewModel>(product.Product);
                viewModel.Add(view);
            }

            return viewModel.OrderByDescending(x => x.Id).ToList();
        }
    }
}
