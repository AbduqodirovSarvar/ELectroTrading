using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Orders.Commands;
using ElectroTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Orders.CommandHandlers
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, OrderViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public CreateOrderCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderViewModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken);
            if (product == null)
                throw new NotFoundException();

            Order order = _mapper.Map<Order>(request);
            order.ProductId = product.Id;

            await _context.Orders.AddAsync(order, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            OrderViewModel view = _mapper.Map<OrderViewModel>(order);
            view.ProductName = product.Name;
            return view;
            
        }
    }
}
