using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Photos.Commands
{
    public class UpdateProductPhotoCommand : ICommand<PhotoViewModel>
    {
        public UpdateProductPhotoCommand(int id, string filename, string filepath)
        {
            ProductId = id;
            FileName = filename;
            FilePath = filepath;
        }

        [Required]
        public int ProductId { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FilePath { get; set; }
    }
}
