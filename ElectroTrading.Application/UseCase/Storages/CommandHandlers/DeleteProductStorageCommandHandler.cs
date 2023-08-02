using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.UseCase.Storages.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Storages.CommandHandlers
{
    public class DeleteProductStorageCommandHandler : ICommandHandler<DeleteProductStorageCommand, bool>
    {
        private readonly IAppDbContext _context;
        public DeleteProductStorageCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteProductStorageCommand request, CancellationToken cancellationToken)
        {
            var st = await _context.Storages.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (st == null)
            {
                throw new NotFoundException();
            }

            _context.Storages.Remove(st);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
