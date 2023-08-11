using AutoMapper;
using ElectroTrading.Application.Abstractions;
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
    public class GetAllEmployeeByFilterQueryHandler : IQueryHandler<GetAllEmployeeByFilterQuery, List<EmployeeViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllEmployeeByFilterQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EmployeeViewModel>> Handle(GetAllEmployeeByFilterQuery request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employees.Include(x => x.Attendances).Include(x => x.EmployeeDebts).Include(x => x.PaymentSalarys).ToListAsync(cancellationToken);
            if (request?.Month != null)
            {
                employees = employees
                    .Where(x =>(x.IsDeleted == false) || (x.DeletedDate != null 
                        && x.DeletedDate.Value.Year >= request.Month.Value.Year 
                            && x.DeletedDate.Value.Month >= request.Month.Value.Month)).ToList();
            }

            var result = new List<EmployeeViewModel>();
            foreach (var item in employees)
            {
                var viewModel = _mapper.Map<EmployeeViewModel>(item);
                viewModel.Attendances = _mapper.Map<List<AttendanceViewModel>>(item.Attendances.Where(x => x.CreatedDate.Month == DateTime.UtcNow.Month).ToList());
                if (item.PaymentSalarys == null || item.PaymentSalarys.Count < 1)
                {
                    viewModel.Debts = _mapper.Map<List<DebtViewModel>>(item.EmployeeDebts);
                }
                else
                {
                    viewModel.Salaries = _mapper.Map<List<SalaryViewModel>>(item.PaymentSalarys.Where(x => x.CreatedDate.Year == DateTime.UtcNow.Year).ToList());
                    viewModel.Debts = _mapper.Map<List<DebtViewModel>>(item.EmployeeDebts.Where(x => x.CreatedDate > item.PaymentSalarys?.OrderBy(x => x.Id).Last().CreatedDate).ToList());
                }
                result.Add(viewModel);
            }

            return result.OrderByDescending(x => x.Id).ToList();
        }
    }
}
