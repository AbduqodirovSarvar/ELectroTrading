using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Salary.Commands
{
    public class CreateSalaryPaymentCommand : ICommand<SalaryViewModel>
    {
        public CreateSalaryPaymentCommand() { }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public decimal Summs { get; set; }
    }
}
