using ElectroTrading.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.OnSale.Commands
{
    public class DeleteOnSaleCommand : ICommand<bool>
    {
        public DeleteOnSaleCommand(int id) { ProductId = id; }
        [Required]
        public int ProductId { get; set; }
    }
}
