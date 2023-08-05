using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.ProductCompositions.Commands
{
    public class CreateProductCompositionCommand : ICommand<ProductViewModel>
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public List<Comp> CompositionIds { get; set; } = new List<Comp>();
    }

    public class Comp
    {
        public int CompositionId { get; set; }
        public double Amount { get; set; }
    }
}
