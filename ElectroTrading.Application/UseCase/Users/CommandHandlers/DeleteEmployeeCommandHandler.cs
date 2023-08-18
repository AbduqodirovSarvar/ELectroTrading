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
    public class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IAppDbContext _context;
        public DeleteEmployeeCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (employee == null)
            {
                throw new NotFoundException();
            }

            employee.IsDeleted = true;
            employee.DeletedDate = DateTime.UtcNow;

            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
