﻿using ElectroTrading.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElectroTrading.Application.UseCase.Products.Commands
{
    public class DeleteProductCommand : ICommand<bool>
    {
        public DeleteProductCommand(int Id) { ProductId = Id; }
        [Required]
        public int ProductId { get; set; }
    }
}
