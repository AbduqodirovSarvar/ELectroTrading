using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.DTOs;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElectroTrading.Application.UseCase.Attendances.Commands
{
    public class CreateAttendanceCommand : ICommand<List<AttendanceViewModel>>
    {
        public CreateAttendanceCommand(List<AttendanceCreateDto> attendances)
        {
            Attendances = attendances;
        }

        public List<AttendanceCreateDto> Attendances { get; set; } = new List<AttendanceCreateDto>();
    }
}
