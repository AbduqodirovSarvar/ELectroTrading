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
    public class EmployeeGetAllQueryHandler : IQueryHandler<EmployeeGetAllQuery, List<EmployeeViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeGetAllQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EmployeeViewModel>> Handle(EmployeeGetAllQuery request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employees.ToListAsync(cancellationToken);

            return _mapper.Map<List<EmployeeViewModel>>(employees);
        }
    }
}
