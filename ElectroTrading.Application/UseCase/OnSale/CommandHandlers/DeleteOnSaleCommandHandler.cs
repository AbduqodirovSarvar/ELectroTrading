using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.UseCase.OnSale.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.OnSale.CommandHandlers
{
    public class DeleteOnSaleCommandHandler : ICommandHandler<DeleteOnSaleCommand, bool>
    {
        private readonly IAppDbContext _context;
        public DeleteOnSaleCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteOnSaleCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException();
            }

            product.IsOnSale = false;

            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
