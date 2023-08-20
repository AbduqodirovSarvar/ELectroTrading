using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.UseCase.Salary.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Salary.CommandHandlers
{
    public class DeleteDebtCommandHandler : ICommandHandler<DeleteDebtCommand, bool>
    {
        private readonly IAppDbContext _context;
        public DeleteDebtCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteDebtCommand request, CancellationToken cancellationToken)
        {
            var debt = await _context.EmployeesDebts.FirstOrDefaultAsync(x => x.Id == request.DebtId, cancellationToken);
            if (debt == null)
            {
                throw new NotFoundException();
            }

            _context.EmployeesDebts.Remove(debt);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
                else
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }
            return true;
        }
    }
}
