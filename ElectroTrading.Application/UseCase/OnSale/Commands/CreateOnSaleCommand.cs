using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.OnSale.Commands
{
    public class CreateOnSaleCommand : ICommand<ProductViewModel>
    {
        public CreateOnSaleCommand() { } 
        public CreateOnSaleCommand(int id) { ProductId = id; }
        [Required]
        public int ProductId { get; set; }
    }
}
