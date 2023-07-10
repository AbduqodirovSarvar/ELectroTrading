using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Domain.Domains
{
    public class Master
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    }
}
