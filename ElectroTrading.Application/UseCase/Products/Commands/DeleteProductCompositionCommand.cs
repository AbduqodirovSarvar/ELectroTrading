using ElectroTrading.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElectroTrading.Application.UseCase.Products.Commands
{
    public class DeleteProductCompositionCommand : ICommand<bool>
    {
        public DeleteProductCompositionCommand(int id ) { CompositionId = id; }
        [Required]
        public int CompositionId { get; set; }
    }
}
