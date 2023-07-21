using AutoMapper;
using ElectroTrading.Application.Abstractions;
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
    public class AttendanceCreateCommandHandler : ICommandHandler<AttendanceCreateCommand, List<AttendanceViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public AttendanceCreateCommandHandler(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<List<AttendanceViewModel>> Handle(AttendanceCreateCommand request, CancellationToken cancellationToken)
        {
            var attendances = await _context.Attendances.ToListAsync(cancellationToken);
            foreach (var attendance in request.Attendances)
            {
                if (attendances.Any(x => x.Day == attendance.Day && x.EmployeeId == attendance.EmployeeId))
                    continue;

                var attend = _mapper.Map<Attendance>(attendance);
                attend.ByWhomId = _currentUserService.UserId;
                await _context.Attendances.AddAsync(attend, cancellationToken);
            }
            await _context.SaveChangesAsync(cancellationToken);
            attendances = await _context.Attendances.Where(x => x.CreatedDate.Day == DateTime.UtcNow.Day).ToListAsync(cancellationToken);
            return _mapper.Map<List<AttendanceViewModel>>(attendances);
        }
    }
}
