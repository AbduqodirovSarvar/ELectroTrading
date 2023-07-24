using ElectroTrading.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public CategoryUnity Category { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public ICollection<ProductComposition> Compositions { get; set; } = new HashSet<ProductComposition>();
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public ICollection<FinishedProduct> FinishedProducts { get; set; } = new HashSet<FinishedProduct>();
        public ICollection<BoughtAndSoldProduct> BoughtAndSoldProducts { get; set; } = new HashSet<BoughtAndSoldProduct>();
        public ICollection<Storage> Storages { get; set; } = new HashSet<Storage>();
    }
}
