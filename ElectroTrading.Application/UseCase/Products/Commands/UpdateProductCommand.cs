using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.DTOs;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Domain.Entities;
using ElectroTrading.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElectroTrading.Application.UseCase.Products.Commands
{
    public class UpdateProductCommand : ICommand<ProductViewModel>
    {
        public UpdateProductCommand() { }
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; } = null;
        public string? Description { get; set; } = null;
        public decimal? Price { get; set; } = null;
        public CategoryUnity? Category { get; set; } = null;
        public List<UpdateProductCompositionDto>? Compositions { get; set; } = null;
    }
}
