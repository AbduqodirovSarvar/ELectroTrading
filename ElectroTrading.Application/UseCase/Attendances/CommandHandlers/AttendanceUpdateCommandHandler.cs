using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Attendances.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Attendances.CommandHandlers
{
    public class AttendanceUpdateCommandHandler : ICommandHandler<AttendanceUpdateCommand, AttendanceViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public AttendanceUpdateCommandHandler(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<AttendanceViewModel> Handle(AttendanceUpdateCommand request, CancellationToken cancellationToken)
        {
            var attend = await _context.Attendances.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (attend == null)
            {
                throw new NotFoundException();
            }
            attend.IsExtraWork = request?.IsExtraWork ?? attend.IsExtraWork;
            attend.IsMainWork = request?.IsMainWork ?? attend.IsMainWork;
            attend.CreatedDate = DateTime.UtcNow;
            attend.ByWhomId = _currentUserService.UserId;

            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<AttendanceViewModel>(attend);
        }
    }
}
