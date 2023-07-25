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
            var employees = await _context.Employees.ToListAsync(cancellationToken);
            if (request?.Year != null)
            {
                employees = employees.Where(x => (x.IsDeleted == false) | (x.DeletedDate != null && x.DeletedDate.Value.Year <= request.Year)).ToList();
            }

            if (request?.Month != null)
            {
                employees = employees.Where(x => (x.IsDeleted == false) | (x.DeletedDate != null && x.DeletedDate.Value.Month <= request.Month)).ToList();
            }

            if (request?.Day != null) 
            {
                employees = employees.Where(x => (x.IsDeleted == false) | (x.DeletedDate != null && x.DeletedDate.Value.Day <= request.Day)).ToList();
            }

            return _mapper.Map<List<EmployeeViewModel>>(employees);
        }
    }
}
