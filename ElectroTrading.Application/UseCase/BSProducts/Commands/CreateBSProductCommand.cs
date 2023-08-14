using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Domain.Entities;
using ElectroTrading.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.BSProducts.Commands
{
    public class CreateBSProductCommand : ICommand<BSProductViewModel>
    {
        [Required]
        public int ProductId { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Amount { get; set; }
        public decimal Price { get; set; }
        public decimal Avans { get; set; }
        [Required]
        public CategoryProcess Category { get; set; }
    }
}
