using ElectroTrading.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Photos.Commands
{
    public class DeleteProductPhotoCommand : ICommand<bool>
    {
        public DeleteProductPhotoCommand(int id) { ProductId = id; }
        [Required]
        public int ProductId { get; set; }
    }
}
