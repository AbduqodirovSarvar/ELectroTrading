using AutoMapper;
using ElectroTrading.Application.Abstractions;
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
    public class AttendanceGetAllQueryHandler : IQueryHandler<AttendancesGetAllQuery, List<AttendanceViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public AttendanceGetAllQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AttendanceViewModel>> Handle(AttendancesGetAllQuery request, CancellationToken cancellationToken)
        {
            var attendances = await _context.Attendances.ToListAsync(cancellationToken);
            return _mapper.Map<List<AttendanceViewModel>>(attendances);
        }
    }
}
