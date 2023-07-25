using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.UseCase.Orders.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Orders.CommandHandlers
{
    public class DeleteOrderCommandHandler : ICommandHandler<DeleteOrderCommand, bool>
    {
        private readonly IAppDbContext _context;
        public DeleteOrderCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.OrderId, cancellationToken);
            if (order == null)
                throw new NotFoundException();

            _context.Orders.Remove(order);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
