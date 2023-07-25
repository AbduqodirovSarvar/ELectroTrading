using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Attendances.Commands
{
    public class DeleteAttendanceCommand : ICommand<bool>
    {
        public List<int> AttendanceIds { get; set; } = new List<int>();
    }
}
