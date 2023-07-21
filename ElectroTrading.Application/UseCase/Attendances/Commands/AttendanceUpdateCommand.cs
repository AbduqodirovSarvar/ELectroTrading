using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Attendances.Commands
{
    public class AttendanceUpdateCommand : ICommand<AttendanceViewModel>
    {
        [Required]
        public int Id { get; set; }
        public bool? IsMainWork { get; set; }
        public bool? IsExtraWork { get; set; }
    }
}
