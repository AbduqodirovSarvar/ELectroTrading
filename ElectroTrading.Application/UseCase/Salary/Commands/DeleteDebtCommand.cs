using ElectroTrading.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElectroTrading.Application.UseCase.Salary.Commands
{
    public class DeleteDebtCommand : ICommand<bool>
    {
        public DeleteDebtCommand(int id) { DebtId = id; }
        [Required]
        public int DebtId { get; set; }
    }
}
