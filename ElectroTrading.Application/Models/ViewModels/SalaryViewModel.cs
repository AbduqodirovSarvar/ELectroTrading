﻿using ElectroTrading.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Models.ViewModels
{
    public class SalaryViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeViewModel? Employee { get; set; }
        public decimal Summs { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal TotalDebtSumms { get; set; }
        public List<DebtViewModel> Debts { get; set; } = new List<DebtViewModel>();
        public int ByWhomId { get; set; }
    }
}
