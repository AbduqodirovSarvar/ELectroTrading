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
    public class DeleteSalaryCommandHandler : ICommandHandler<DeleteDebtCommand, bool>
    {
        private readonly IAppDbContext _context;
        public DeleteSalaryCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteDebtCommand request, CancellationToken cancellationToken)
        {
            var salary = await _context.PaymentSalaries.FirstOrDefaultAsync(x => x.Id == request.DebtId, cancellationToken);
            if (salary == null)
                throw new NotFoundException();

            _context.PaymentSalaries.Remove(salary);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
