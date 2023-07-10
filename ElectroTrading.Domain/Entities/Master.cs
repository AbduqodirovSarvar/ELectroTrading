using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Domain.Entities
{
    public class Master
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public string Password { get; set; } = "Password";
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public ICollection<Attendance> Attendances { get; set; } = new HashSet<Attendance>();
        public ICollection<EmployeeDebt> EmployeeDebts { get; set; } = new HashSet<EmployeeDebt>();
        public ICollection<PaymentSalary> PaymentSalarys { get; set; } = new HashSet<PaymentSalary>();
    }
}
