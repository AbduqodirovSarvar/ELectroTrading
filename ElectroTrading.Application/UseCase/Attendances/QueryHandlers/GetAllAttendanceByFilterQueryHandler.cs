using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Attendances.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Attendances.QueryHandlers
{
    public class GetAllAttendanceByFilterQueryHandler : IQueryHandler<GetAllAttendanceByFilterQuery, List<AttendanceViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllAttendanceByFilterQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AttendanceViewModel>> Handle(GetAllAttendanceByFilterQuery request, CancellationToken cancellationToken)
        {
            var attends = await _context.Attendances.ToListAsync(cancellationToken);

            if (request?.EmployeeId != null)
            {
                attends = attends.Where(x => x.EmployeeId == request.EmployeeId).ToList();
            }

            if (request?.Year != null)
            {
                attends = attends.Where(x => x.Day.Year == request.Year).ToList();
            }

            if (request?.Month != null)
            {
                attends = attends.Where(x => x.Day.Month.Equals(request.Month)).ToList();
            }

            if (request?.Day != null)
            {
                attends = attends.Where(x => x.Day.Day.Equals(request.Day)).ToList();
            }

            List<AttendanceViewModel> attendViews = _mapper.Map<List<AttendanceViewModel>>(attends);

            foreach (var x in attendViews)
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == x.EmployeeId, cancellationToken);
                if (employee != null)
                {
                    x.FirstName = employee.Name;
                    x.LastName = employee.LastName;
                    x.Position = employee.Position;
                }
            }

            return attendViews.OrderByDescending(x => x.Id).ToList();
        }
    }
}
