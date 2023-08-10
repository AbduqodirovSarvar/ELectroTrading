using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.FinishedProducts.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.FinishedProducts.QueryHandlers
{
    public class GetAllFinishedProductQueryHandler : IQueryHandler<GetAllFinishedProductQuery, List<FinishedProductViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllFinishedProductQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<FinishedProductViewModel>> Handle(GetAllFinishedProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.FinishedProducts.Include(x => x.Product).ToListAsync(cancellationToken);

            List<FinishedProductViewModel> result = new List<FinishedProductViewModel>();

            foreach (var product in products)
            {
                var viewModel = _mapper.Map<FinishedProductViewModel>(product);
                viewModel.Product = _mapper.Map<ProductViewModel>(product.Product);
                result.Add(viewModel);
            }

            return result.OrderByDescending(x => x.Id).ToList();
        }
    }
}
