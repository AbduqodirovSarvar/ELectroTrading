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
    public class UpdateEmployeeCommand : ICommand<EmployeeViewModel>
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? PassportId { get; set; } = null;
        public string? Position { get; set; } = null;
        public string? Phone { get; set; } = null;
        public decimal? Salary { get; set; } = null;
        public DateOnly? Experience { get; set; } = null;
        public bool? IsDeleted { get; set; } = null;
    }
}
