using ElectroTrading.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = "Password";
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public UserRole Role { get; set; } = UserRole.Employee;
    }
}
