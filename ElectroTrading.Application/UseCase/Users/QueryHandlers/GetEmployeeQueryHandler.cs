using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Users.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Users.QueryHandlers
{
    public class GetEmployeeQueryHandler : IQueryHandler<GetEmployeeQuery, EmployeeViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetEmployeeQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeViewModel> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.Include(x => x.PaymentSalarys).Include(x => x.EmployeeDebts).Include(x => x.Attendances).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (employee == null)
                throw new NotFoundException();

            EmployeeViewModel viewModel = _mapper.Map<EmployeeViewModel>(employee);
            viewModel.Attendances = _mapper.Map<List<AttendanceViewModel>>(employee.Attendances.Where(x => x.Day.Month == DateTime.UtcNow.Month));
            if (employee.PaymentSalarys == null || employee.PaymentSalarys.Count < 1)
            {
                viewModel.Debts = _mapper.Map<List<DebtViewModel>>(employee.EmployeeDebts);
            }
            else
            {
                viewModel.Salaries = _mapper.Map<List<SalaryViewModel>>(employee.PaymentSalarys.Where(x => x.CreatedDate.Year == DateTime.UtcNow.Year).ToList());
                viewModel.Debts = _mapper.Map<List<DebtViewModel>>(employee.EmployeeDebts.Where(x => x.CreatedDate > employee.PaymentSalarys?.OrderBy(x => x.Id).Last().CreatedDate).ToList());
            }

            return viewModel;
        }
    }
}
