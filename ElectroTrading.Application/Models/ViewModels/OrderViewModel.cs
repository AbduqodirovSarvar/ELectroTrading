using ElectroTrading.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel? Product { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public double Amount { get; set; }
        public decimal Avans { get; set; }
        public DateOnly DeadLine { get; set; }
        public bool IsSubmitted { get; set; } = false;
        public DateTime? SubmitDate { get; set; } = null;
        public DateTime CreatedDate { get; set; }
    }
}
