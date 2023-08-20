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
    public class DeleteSalaryCommandHandler : ICommandHandler<DeleteSalaryCommand, bool>
    {
        private readonly IAppDbContext _context;
        public DeleteSalaryCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteSalaryCommand request, CancellationToken cancellationToken)
        {
            var salary = await _context.PaymentSalaries.FirstOrDefaultAsync(x => x.Id == request.SalaryId, cancellationToken);
            if (salary == null)
            {
                throw new NotFoundException();
            }

            _context.PaymentSalaries.Remove(salary);
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
