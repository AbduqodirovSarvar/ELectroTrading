using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.UseCase.ProductCompositions.Commands;
using ElectroTrading.Application.UseCase.Products.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.ProductCompositions.CommandHandlers
{
    public class DeleteProductCompositionCommandHandler : ICommandHandler<DeleteProductCompositionCommand, bool>
    {
        private readonly IAppDbContext _context;
        public DeleteProductCompositionCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteProductCompositionCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Include(x => x.Compositions).FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException();
            }

            if (request?.CompositionIds != null)
            {
                foreach (var id in request.CompositionIds)
                {
                    var comp = await _context.ProductCompositions.FirstOrDefaultAsync(x => x.ProductId == product.Id && x.CompositionId == id, cancellationToken);
                    if (comp == null)
                    {
                        continue;
                    }
                    product.Compositions.Remove(comp);
                }
            }


            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
