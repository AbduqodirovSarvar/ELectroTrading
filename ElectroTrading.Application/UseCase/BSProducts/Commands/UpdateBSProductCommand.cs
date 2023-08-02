using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.BSProducts.Commands
{
    public class UpdateBSProductCommand : ICommand<BSProductViewModel>
    {
        [Required]
        public int Id { get; set; }
        public string? Description { get; set; } = null;
        public double? Amount { get; set; } = null;
        public decimal? Price { get; set; } = null;
        public CategoryProcess? Category { get; set; } = null;
    }
}
