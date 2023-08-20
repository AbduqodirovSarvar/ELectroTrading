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
    public class DeleteAttendanceCommandHandler : ICommandHandler<DeleteAttendanceCommand, bool>
    {
        private readonly IAppDbContext _context;
        public DeleteAttendanceCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteAttendanceCommand request, CancellationToken cancellationToken)
        {
            foreach(var id in request.AttendanceIds)
            {
                var attend = await _context.Attendances.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
                if (attend == null)
                {
                    throw new NotFoundException();
                }

                _context.Attendances.Remove(attend);
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
            return true;
        }
    }
}
