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
    public class GetAllDebtByFilterQueryHandler : IQueryHandler<GetAllDebtByFilterQuery, DebtListViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllDebtByFilterQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DebtListViewModel> Handle(GetAllDebtByFilterQuery request, CancellationToken cancellationToken)
        {
            var debts = await _context.EmployeesDebts.Include(x => x.Employee).ToListAsync(cancellationToken);
            DebtListViewModel res = new DebtListViewModel();
            if (debts == null || debts.Count < 1)
            {
                return res;
            }
            if (request?.EmployeeId != null)
            {
                debts = debts.Where(x => x.EmployeeId == request.EmployeeId).ToList();
            }

            if (request?.Year != null)
            {
                debts = debts
                    .Where(x => x.CreatedDate.Year == request.Year).ToList();
            }

            if (request?.Month != null)
            {
                debts = debts
                    .Where(x => x.CreatedDate.Month == request.Month).ToList();
            }

            if (request?.Day != null)
            {
                debts = debts
                    .Where(x => x.CreatedDate.Day == request.Day).ToList();
            }

            List<DebtViewModel> result = _mapper.Map<List<DebtViewModel>>(debts);

            res.EmployeeId = result.First().EmployeeId;
            res.TotalDebtSumms = result.Sum(x => x.Summs);
            res.Debts = result.OrderByDescending(x => x.Id).ToList();

            return res;
        }
    }
}
