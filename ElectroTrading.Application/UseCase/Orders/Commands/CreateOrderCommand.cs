using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Orders.Commands
{
    public class CreateOrderCommand : ICommand<OrderViewModel>
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public double Amount { get; set; }
        public decimal Avans { get; set; }
        [Required]
        public DateOnly DeadLine { get; set; }
    }
}
