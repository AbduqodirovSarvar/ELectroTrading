
using ElectroTrading.Domain.Entities;
using ElectroTrading.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Models.ViewModels
{
    public class BSProductViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel? Product { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Amount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public CategoryProcess Category { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
