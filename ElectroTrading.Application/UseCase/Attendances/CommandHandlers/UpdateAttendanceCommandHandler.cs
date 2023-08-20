using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Attendances.Commands;
using ElectroTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Attendances.CommandHandlers
{
    public class UpdateAttendanceCommandHandler : ICommandHandler<UpdateAttendanceCommand, List<AttendanceViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public UpdateAttendanceCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AttendanceViewModel>> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
        {
            List<AttendanceViewModel> result = new List<AttendanceViewModel>();
            AttendanceViewModel view;
            Employee? employee;
            foreach (var attend in request.Attendances)
            {
                var attendance = await _context.Attendances.FirstOrDefaultAsync(x => x.Id == attend.Id, cancellationToken);
                if(attendance == null)
                {
                    throw new NotFoundException();
                }

                attendance.IsMainWork = attend?.IsMainWork ?? attendance.IsMainWork;
                attendance.LateHours = attend?.LateHours ?? attendance.LateHours;
                attendance.ExtraWorkHours = attend?.ExtraWorkHours ?? attendance.ExtraWorkHours;

                view = _mapper.Map<AttendanceViewModel>(attendance);

                employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == attendance.EmployeeId, cancellationToken);

                if (employee == null)
                    throw new NotFoundException();

                view.FirstName = employee.Name;
                view.LastName = employee.LastName;
                view.Position = employee.Position;
                result.Add(view);
            }
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
                else
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }
            return result;

        }
    }
}
