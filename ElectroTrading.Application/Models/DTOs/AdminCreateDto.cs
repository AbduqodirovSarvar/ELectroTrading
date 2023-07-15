using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Models.DTOs
{
    public class AdminCreateDto
    {
        public int EmployeeId { get; set; }
        public string Password { get; set; } = "Password";
    }
}
