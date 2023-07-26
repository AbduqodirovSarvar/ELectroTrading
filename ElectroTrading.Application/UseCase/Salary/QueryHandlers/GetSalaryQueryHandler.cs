using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Salary.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Salary.QueryHandlers
{
    public class GetSalaryQueryHandler : IQueryHandler<GetSalaryQuery, SalaryViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetSalaryQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SalaryViewModel> Handle(GetSalaryQuery request, CancellationToken cancellationToken)
        {
            var salary = await _context.PaymentSalaries.Include(x => x.Employee).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (salary == null)
                throw new NotFoundException();

            SalaryViewModel viewModel = _mapper.Map<SalaryViewModel>(salary);
            viewModel.Employee = _mapper.Map<EmployeeViewModel>(salary.Employee);
            viewModel.Debts = _mapper.Map<List<DebtViewModel>>(await _context.EmployeesDebts.Where(x => x.EmployeeId == salary.EmployeeId).ToListAsync(cancellationToken));
            viewModel.TotalDebtSumms = viewModel.Debts.Select(x => x.Summs).Sum();

            return viewModel;
        }
    }
}
