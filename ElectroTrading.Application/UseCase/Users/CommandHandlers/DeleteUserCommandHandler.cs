using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.UseCase.Users.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Users.CommandHandlers
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, bool>
    {
        private readonly IAppDbContext _context;
        public DeleteUserCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException();
            }

            _context.Users.Remove(user);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
