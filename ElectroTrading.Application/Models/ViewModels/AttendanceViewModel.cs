using ElectroTrading.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Models.ViewModels
{
    public class AttendanceViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public DateOnly Day { get; set; }
        public bool IsMainWork { get; set; }
        public double ExtraWorkHours { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ByWhomId { get; set; }
    }
}
