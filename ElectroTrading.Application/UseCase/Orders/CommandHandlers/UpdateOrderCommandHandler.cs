using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Orders.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Orders.CommandHandlers
{
    public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand, OrderViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public UpdateOrderCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OrderViewModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.OrderId, cancellationToken);
            if (order == null)
                throw new NotFoundException();

            order.Description = request?.Description ?? order.Description;
            order.DeadLine = request?.DeadLine ?? order.DeadLine;
            order.Amount = request?.Amount ?? order.Amount;
            order.Price = request?.Price ?? order.Price;

            if(request?.IsSubmitted != null && request.IsSubmitted == true)
            {
                order.IsSubmitted = request.IsSubmitted.Value;
                order.SubmitDate = DateTime.UtcNow;
            }

            return _mapper.Map<OrderViewModel>(order);
        }
    }
}
