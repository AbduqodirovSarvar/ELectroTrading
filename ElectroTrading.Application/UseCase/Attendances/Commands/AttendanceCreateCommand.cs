using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.DTOs;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Attendances.Commands
{
    public class AttendanceCreateCommand : ICommand<List<AttendanceViewModel>>
    {
        public AttendanceCreateCommand() { }
        public List<AttendanceCreateDto> Attendances { get; set; } = new List<AttendanceCreateDto>();
    }
}
