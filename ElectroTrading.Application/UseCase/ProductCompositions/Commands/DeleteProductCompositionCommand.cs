using ElectroTrading.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElectroTrading.Application.UseCase.ProductCompositions.Commands
{
    public class DeleteProductCompositionCommand : ICommand<bool>
    {
        public DeleteProductCompositionCommand(int productid, List<int> compids) 
        {
            ProductId = productid;
            CompositionIds = compids;
        }
        [Required]
        public int ProductId { get; set; }
        public List<int> CompositionIds { get; set; } = new List<int>();
    }
}
