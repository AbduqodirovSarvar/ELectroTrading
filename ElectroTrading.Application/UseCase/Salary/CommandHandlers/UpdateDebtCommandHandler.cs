using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Salary.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Salary.CommandHandlers
{
    public class UpdateDebtCommandHandler : ICommandHandler<UpdateDebtCommand, DebtViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public UpdateDebtCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DebtViewModel> Handle(UpdateDebtCommand request, CancellationToken cancellationToken)
        {
            var debt = await _context.EmployeesDebts.Include(x => x.Employee).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (debt == null)
            {
                throw new NotFoundException();
            }

            debt.Summs = request?.Summs ?? debt.Summs;
            debt.Description = request?.Description ?? debt.Description;

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

            DebtViewModel viewModel = _mapper.Map<DebtViewModel>(debt);
            viewModel.Employee = _mapper.Map<EmployeeViewModel>(debt.Employee);
            
            return viewModel;
        }
    }
}
