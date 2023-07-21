using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Users.Commands;
using ElectroTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Users.CommandHandlers
{
    public class EmployeeCreateCommandHandler : ICommandHandler<EmployeeCreateCommand, EmployeeViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeCreateCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeViewModel> Handle(EmployeeCreateCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Phone == request.Phone, cancellationToken);
            if (employee != null)
            {
                throw new AlreadyExistsException();
            }
            employee = _mapper.Map<Employee>(request);
            /*employee.JoinedDate = new DateOnly(request.JoinedDate.Year, request.JoinedDate.Month, request.JoinedDate.Day);*/
            employee.CreatedTime = DateTime.UtcNow;

            await _context.Employees.AddAsync(employee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            
            return _mapper.Map<EmployeeViewModel>(await _context.Employees.FirstOrDefaultAsync(x => x.Phone == employee.Phone, cancellationToken));
        }
    }
}
