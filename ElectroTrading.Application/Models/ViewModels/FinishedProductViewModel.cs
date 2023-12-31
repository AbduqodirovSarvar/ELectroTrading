﻿using ElectroTrading.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Models.ViewModels
{
    public class FinishedProductViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel? Product { get; set; }
        public double Amount { get; set; }
        public string Desciption { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
