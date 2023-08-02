using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.BSProducts.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.BSProducts.CommandHandlers
{
    public class DeleteBSProductCommandHandler : ICommandHandler<DeleteBSProductCommand, bool>
    {
        private readonly IAppDbContext _context;
        public DeleteBSProductCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteBSProductCommand request, CancellationToken cancellationToken)
        {
            var bs = await _context.BoughtAndSoldsProducts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (bs == null)
            {
                throw new NotFoundException();
            }

            _context.BoughtAndSoldsProducts.Remove(bs);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
