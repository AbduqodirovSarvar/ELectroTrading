using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Attendances.Commands;
using ElectroTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
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
        private readonly ISendTelegramMessage _sendMsg;
        public CreateAttendanceCommandHandler(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService, ISendTelegramMessage sendMsg)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _sendMsg = sendMsg;
        }

        public async Task<List<AttendanceViewModel>> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var requests = request.Attendances.ToList();
            List<AttendanceViewModel> views = new List<AttendanceViewModel>();
            foreach(var attendance in requests)
            {
                AttendanceViewModel view;
                var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == attendance.EmployeeId, cancellationToken);
                if (employee != null && (await _context.Attendances.FirstOrDefaultAsync(x => x.EmployeeId == attendance.EmployeeId && x.Day == attendance.Day, cancellationToken)) == null)
                {
                    var attend = _mapper.Map<Attendance>(attendance);
                    attend.ByWhomId = _currentUserService.UserId;
                    await _context.Attendances.AddAsync(attend, cancellationToken);
                    view = _mapper.Map<AttendanceViewModel>(attend);
                    view.FirstName = employee.Name;
                    view.LastName = employee.LastName;
                    view.Position = employee.Position;
                    views.Add(view);
                }
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

            await _sendMsg.SendMessage(await _sendMsg.MakeAttendanceText(views));
            
            return views;
        }
    }
}