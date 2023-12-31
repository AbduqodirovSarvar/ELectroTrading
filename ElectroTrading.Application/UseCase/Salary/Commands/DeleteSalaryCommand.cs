﻿using ElectroTrading.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElectroTrading.Application.UseCase.Salary.Commands
{
    public class DeleteSalaryCommand : ICommand<bool>
    {
        public DeleteSalaryCommand(int id) { SalaryId = id; }
        [Required]
        public int SalaryId { get; set; }
    }
}
