using ElectroTrading.Domain.Entities;
using ElectroTrading.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public CategoryUnity Category { get; set; }
        public decimal TotalCompPrice { get; set; }
        public List<ProductCompositionViewModel> Compositions { get; set; } = new List<ProductCompositionViewModel>();
        public DateTime CreatedDate { get; set; }
    }
}
