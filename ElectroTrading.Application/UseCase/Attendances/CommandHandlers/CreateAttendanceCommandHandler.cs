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
    public class CreateAttendanceCommandHandler : ICommandHandler<CreateAttendanceCommand, List<AttendanceViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public CreateAttendanceCommandHandler(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<List<AttendanceViewModel>> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var requests = request.Attendances.ToList();
            List<AttendanceViewModel> views = new List<AttendanceViewModel>();
            foreach(var attendance in requests)
            {
                AttendanceViewModel view;
                var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == attendance.EmployeeId, cancellationToken);
                if (employee != null)
                {
                    await _context.Attendances.AddAsync(_mapper.Map<Attendance>(attendance));
                    view = _mapper.Map<AttendanceViewModel>(attendance);
                    view.FirstName = employee.Name;
                    view.LastName = employee.LastName;
                    view.Position = employee.Position;
                    views.Add(view);
                }
            }
            await _context.SaveChangesAsync(cancellationToken);

            return views;
        }
    }
}