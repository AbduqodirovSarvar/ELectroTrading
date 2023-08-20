using ElectroTrading.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Phone { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(5)).DateTime;
        public UserRole Role { get; set; } = UserRole.Employee;
    }
}
