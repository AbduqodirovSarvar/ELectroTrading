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
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (employee == null)
                throw new NotFoundException();

            return _mapper.Map<EmployeeViewModel>(employee);
        }
    }
}
