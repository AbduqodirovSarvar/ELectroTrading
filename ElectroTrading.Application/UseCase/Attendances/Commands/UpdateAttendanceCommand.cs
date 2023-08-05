using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.DTOs;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElectroTrading.Application.UseCase.Attendances.Commands
{
    public class UpdateAttendanceCommand : ICommand<List<AttendanceViewModel>>
    {
        public UpdateAttendanceCommand(List<UpdateAttendanceDto> dto) { Attendances = dto; }
        public List<UpdateAttendanceDto> Attendances { get; set; } = new List<UpdateAttendanceDto>();
    }
}
