using ElectroTrading.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Models.DTOs
{
    public class AttendanceCreateDto
    {
        [Required]
        public int EmployeeId { get; set; }
        public DateOnly Day { get; set; } = new DateOnly(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
        public bool IsMainWork { get; set; } = false;
        public double LateHours { get; set; }
        public double ExtraWorkHours { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
