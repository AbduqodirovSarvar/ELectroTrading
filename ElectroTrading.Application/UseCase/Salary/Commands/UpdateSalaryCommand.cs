using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElectroTrading.Application.UseCase.Salary.Commands
{
    public class UpdateSalaryCommand : ICommand<SalaryViewModel>
    {
        public UpdateSalaryCommand() { }
        [Required]
        public int Id { get; set; }
        public decimal? Summs { get; set; } = null;
    }
}
