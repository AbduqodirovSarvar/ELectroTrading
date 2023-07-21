using AutoMapper;
using ElectroTrading.Application.Abstractions;
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
    public class EmployeeGetAllAttendanceQueryHandler : IQueryHandler<EmployeeGetAllAttendancesQuery, List<AttendanceViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeGetAllAttendanceQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AttendanceViewModel>> Handle(EmployeeGetAllAttendancesQuery request, CancellationToken cancellationToken)
        {
            var attendances = await _context.Attendances.Where(x => x.EmployeeId == request.Id).ToListAsync(cancellationToken);
            return _mapper.Map<List<AttendanceViewModel>>(attendances);
        }
    }
}
