using ElectroTrading.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Models.ViewModels
{
    public class ProductCompositionViewModel
    {
        public int ProductId { get; set; }
        public int CompositionId { get; set; }
        public string CompositionName { get; set; } = string.Empty;
        public double Amount { get; set; }
        public decimal Price { get; set; }
    }
}
