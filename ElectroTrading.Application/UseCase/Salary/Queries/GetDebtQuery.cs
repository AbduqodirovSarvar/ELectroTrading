﻿using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Salary.Queries
{
    public class GetDebtQuery : IQuery<DebtViewModel>
    {
        public GetDebtQuery(int id) { Id = id; }
        [Required]
        public int Id { get; set; }
    }
}
