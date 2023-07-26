using AutoMapper;
using ElectroTrading.Application.Abstractions;
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
    public class GetAllSalaryByFilterQueryHandler : IQueryHandler<GetAllSalaryByFilterQuery, List<SalaryViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllSalaryByFilterQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<SalaryViewModel>> Handle(GetAllSalaryByFilterQuery request, CancellationToken cancellationToken)
        {
            var salaries = await _context.PaymentSalaries.Include(x => x.Employee).ToListAsync(cancellationToken);

            if(request?.EmployeeId != null)
            {
                salaries = salaries.Where(x => x.EmployeeId == request.EmployeeId).ToList();
            }

            if(request?.Date != null)
            {
                salaries = salaries
                    .Where(x => x.CreatedDate.Year == request.Date.Value.Year
                        && x.CreatedDate.Month == request.Date.Value.Month
                            && x.CreatedDate.Day == request.Date.Value.Day).ToList();
            }

            return _mapper.Map<List<SalaryViewModel>>(salaries);
        }
    }
}
