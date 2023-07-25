using ElectroTrading.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Orders.Commands
{
    public class DeleteOrderCommand : ICommand<bool>
    {
        public DeleteOrderCommand(int id ) { OrderId = id; }
        [Required]
        public int OrderId { get; set; }
    }
}
