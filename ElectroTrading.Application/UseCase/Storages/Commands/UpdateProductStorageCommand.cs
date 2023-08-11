using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Storages.Commands
{
    public class UpdateProductStorageCommand : ICommand<StorageViewModel>
    {
        [Required]
        public int Id { get; set; }
        public double? Amount { get; set; } = null;
        public string? Description { get; set; } = null;
    }
}
