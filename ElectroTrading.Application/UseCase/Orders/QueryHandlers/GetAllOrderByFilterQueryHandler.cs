using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Orders.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Orders.QueryHandlers
{
    public class GetAllOrderByFilterQueryHandler : IQueryHandler<GetAllOrderByFilterQuery, List<OrderViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllOrderByFilterQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<OrderViewModel>> Handle(GetAllOrderByFilterQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.ToListAsync(cancellationToken);

            List<OrderViewModel> orderViews = new List<OrderViewModel>();
            if (request?.IsSubmitted == true)
            {
                orders = orders.Where(x => x.IsSubmitted == true).ToList();
            }
            foreach( var order in orders)
            {
                var view = _mapper.Map<OrderViewModel>(order);
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == view.ProductId, cancellationToken);
                if (product == null)
                    throw new NotFoundException();

                view.Product = _mapper.Map<ProductViewModel>(product);
                orderViews.Add(view);
            }
            return orderViews.OrderByDescending(x => x.Id).ToList();
        }
    }
}
