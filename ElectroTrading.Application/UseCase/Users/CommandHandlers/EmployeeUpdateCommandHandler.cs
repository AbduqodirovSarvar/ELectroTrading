using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Users.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Users.CommandHandlers
{
    public class EmployeeUpdateCommandHandler : ICommandHandler<EmployeeUpdateCommand, EmployeeViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUpdatePhoneNumber _updatePhone;
        public EmployeeUpdateCommandHandler(IAppDbContext context, IMapper mapper, IUpdatePhoneNumber updatePhone)
        {
            _context = context;
            _mapper = mapper;
            _updatePhone = updatePhone;
        }
        public async Task<EmployeeViewModel> Handle(EmployeeUpdateCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (employee == null)
            {
                throw new NotFoundException();
            }
            employee.Name = request?.Name ?? employee.Name;
            employee.LastName = request?.LastName ?? employee.LastName;
            employee.Phone = request?.Phone ?? employee.Phone;
            employee.Salary = request?.Salary ?? employee.Salary;
            employee.JoinedDate = request?.JoinedDate ?? employee.JoinedDate;
            employee.Position = request?.Position ?? employee.Position;

            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<EmployeeViewModel>(employee);
        }
    }
}
