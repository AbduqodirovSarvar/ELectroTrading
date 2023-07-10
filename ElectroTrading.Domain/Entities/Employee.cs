using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? UserEmployee { get; set; }
        public string Position { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateOnly JoinedDate { get; set; } = new DateOnly(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public ICollection<PaymentSalary> PaymentSalarys { get; set; } = new HashSet<PaymentSalary>();
        public ICollection<Attendance> Attendances { get; set; } = new HashSet<Attendance>();
        public ICollection<EmployeeDebt> EmployeeDebts { get; set; } = new HashSet<EmployeeDebt>();
    }
}
