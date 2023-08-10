using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.FinishedProducts.Commands
{
    public class UpdateFinishedProductCommand : ICommand<FinishedProductViewModel>
    {
        [Required]
        public int ProductId { get; set; }
        public double? Amount { get; set; } = null;
    }
}
