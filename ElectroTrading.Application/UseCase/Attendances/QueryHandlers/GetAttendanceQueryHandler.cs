using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Attendances.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Attendances.QueryHandlers
{
    public class GetAttendanceQueryHandler : IQueryHandler<GetAttendanceQuery, AttendanceViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAttendanceQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AttendanceViewModel> Handle(GetAttendanceQuery request, CancellationToken cancellationToken)
        {
            var attend = await _context.Attendances.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (attend == null)
                throw new NotFoundException();

            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == attend.EmployeeId, cancellationToken);
            if (employee == null)
                throw new NotFoundException();

            var view = _mapper.Map<AttendanceViewModel>(attend);
            view.FirstName = employee.Name;
            view.LastName = employee.LastName;
            view.Position = employee.Position;
            return view;
        }
    }
}
