using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Salary.Commands
{
    public class UpdateDebtCommand : ICommand<DebtViewModel>
    {
        public UpdateDebtCommand() { }
        [Required]
        public int Id { get; set; }
        public decimal? Summs { get; set; } = null;
        public string? Description { get; set; } = null;
    }
}
