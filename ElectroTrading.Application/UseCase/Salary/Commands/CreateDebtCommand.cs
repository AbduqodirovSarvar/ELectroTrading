using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElectroTrading.Application.UseCase.Salary.Commands
{
    public class CreateDebtCommand : ICommand<DebtViewModel>
    {
        public CreateDebtCommand() { }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public decimal Summs { get; set; }
        [Required]
        public string Description { get; set; } = "Description";
    }
}
