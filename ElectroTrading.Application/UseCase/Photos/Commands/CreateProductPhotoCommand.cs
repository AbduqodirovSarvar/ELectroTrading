using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Photos.Commands
{
    public class CreateProductPhotoCommand : ICommand<PhotoViewModel>
    {
        public CreateProductPhotoCommand(int id, string filename, string filepath)
        {
            Id = id;
            FileName = filename;
            FilePath = filepath;
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FilePath { get; set; }
        
    }
}
