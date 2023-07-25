using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Orders.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Orders.QueryHandlers
{
    public class GetOrderQueryHandler : IQueryHandler<GetOrderQuery, OrderViewModel>
    {
        public readonly IAppDbContext _context;
        public readonly IMapper _mapper;
        public GetOrderQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderViewModel> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.OrderId, cancellationToken);
            if (order == null)
                throw new NotFoundException();

            var view = _mapper.Map<OrderViewModel>(order);
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == order.ProductId, cancellationToken);
            if (product == null)
                throw new NotFoundException();
            view.ProductName = product.Name;
            return view;
        }
    }
}
