using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Domain.Domains
{
    public class EmployeeDebt
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public decimal Summs { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ByWhom { get; set; }
        public Master? Master { get; set; }
    }
}
