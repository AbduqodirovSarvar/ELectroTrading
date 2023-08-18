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
    public class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand, EmployeeViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public UpdateEmployeeCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<EmployeeViewModel> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (employee == null)
            {
                throw new NotFoundException();
            }

            employee.Phone = request?.Phone ?? employee.Phone;
            employee.Name = request?.Name ?? employee.Name;
            employee.LastName = request?.LastName ?? employee.LastName;
            employee.PassportId = request?.PassportId ?? employee.PassportId;
            employee.Position = request?.Position ?? employee.Position;
            employee.Salary = request?.Salary ?? employee.Salary;
            employee.Experience = request?.Experience ?? employee.Experience;
            if (request?.IsDeleted != null)
            {
                employee.IsDeleted = request.IsDeleted.Value;
                employee.DeletedDate = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<EmployeeViewModel>(employee);
        }
    }
}
