﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Domain.Entities
{
    public class FinishedProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
