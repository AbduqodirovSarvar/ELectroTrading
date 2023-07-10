using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Domain.Domains
{
    public class Employee
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? UserEmployee { get; set; }
        public string Position { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public DateOnly JoinedDate { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    }
}
