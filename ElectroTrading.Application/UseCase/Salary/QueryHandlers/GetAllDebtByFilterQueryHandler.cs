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
    public class GetAllDebtByFilterQueryHandler : IQueryHandler<GetAllDebtByFilterQuery, List<DebtViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllDebtByFilterQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DebtViewModel>> Handle(GetAllDebtByFilterQuery request, CancellationToken cancellationToken)
        {
            var debts = await _context.EmployeesDebts.Include(x => x.Employee).ToListAsync(cancellationToken);
            
            if (request?.EmployeeId != null)
            {
                debts = debts.Where(x => x.EmployeeId == request.EmployeeId).ToList();
            }
            if (request?.Date != null)
            {
                debts = debts
                    .Where(x => x.CreatedDate.Year == request.Date.Value.Year 
                        && x.CreatedDate.Month == request.Date.Value.Month
                            && x.CreatedDate.Day == request.Date.Value.Day).ToList();
            }

            List<DebtViewModel> result = _mapper.Map<List<DebtViewModel>>(debts);
            return result;
        }
    }
}
