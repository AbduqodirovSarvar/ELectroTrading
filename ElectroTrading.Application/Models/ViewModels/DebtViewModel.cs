using ElectroTrading.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Models.ViewModels
{
    public class DebtViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeViewModel? Employee { get; set; }
        public decimal Summs { get; set; }
        public string Description { get; set; } = "Description";
        public DateTime CreatedDate { get; set; }
        public int ByWhomId { get; set; }
    }
}
