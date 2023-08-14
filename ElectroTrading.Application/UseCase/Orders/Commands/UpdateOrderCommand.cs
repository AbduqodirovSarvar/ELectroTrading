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
    public class UpdateOrderCommand : ICommand<OrderViewModel>
    {
        [Required]
        public int OrderId { get; set; }
        public string? Description { get; set; } = null;
        public decimal? Price { get; set; } = null;
        public double? Amount { get; set; } = null;
        public decimal? Avans { get; set; } = null;
        public DateOnly? DeadLine { get; set; } = null;
        public bool? IsSubmitted { get; set; } = null;

    }
}
