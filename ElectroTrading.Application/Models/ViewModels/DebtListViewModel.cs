using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Models.ViewModels
{
    public class DebtListViewModel
    {
        public DebtListViewModel() { }
        public int EmployeeId { get; set; }
        public decimal TotalDebtSumms { get; set; }
        public ICollection<DebtViewModel> Debts { get; set; } = new HashSet<DebtViewModel>();
    }
}
