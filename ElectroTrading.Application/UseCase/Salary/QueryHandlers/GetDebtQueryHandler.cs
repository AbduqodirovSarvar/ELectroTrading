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
    public class GetDebtQueryHandler : IQueryHandler<GetDebtQuery, DebtViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetDebtQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DebtViewModel> Handle(GetDebtQuery request, CancellationToken cancellationToken)
        {
            var debt = await _context.EmployeesDebts.Include(x => x.Employee).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (debt == null)
            {
                throw new NotFoundException();
            }

            DebtViewModel viewModel = _mapper.Map<DebtViewModel>(debt);
            viewModel.Employee = _mapper.Map<EmployeeViewModel>(debt.Employee);

            return viewModel;
        }
    }
}
