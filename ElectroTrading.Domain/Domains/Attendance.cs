using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Domain.Domains
{
    public class Attendance
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateOnly Day { get; set; } = new DateOnly();
        public bool IsMainWork { get; set; } = false;
        public bool IsExtraWork { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int ByWhom { get; set; }
        public Master? Master { get; set; }
    }
}
