using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.UseCase.Products.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Products.CommandHandlers
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, bool>
    {
        private readonly IAppDbContext _context;
        public DeleteProductCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException();
            }

            _context.Products.Remove(product);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
