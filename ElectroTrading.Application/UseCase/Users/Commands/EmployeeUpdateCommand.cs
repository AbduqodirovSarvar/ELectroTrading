using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Users.Commands
{
    public class EmployeeUpdateCommand : ICommand<EmployeeViewModel>
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public string? Phone { get; set; }
        public decimal? Salary { get; set; }
        public DateOnly? JoinedDate { get; set; }
    }
}
