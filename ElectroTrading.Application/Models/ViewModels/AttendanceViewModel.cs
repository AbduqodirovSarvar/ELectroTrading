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
        public DateOnly Day { get; set; }
        public bool IsMainWork { get; set; }
        public bool IsExtraWork { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ByWhomId { get; set; }
    }
}
