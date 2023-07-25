using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Users.Commands
{
    public class CreateUserCommand : ICommand<UserViewModel>
    {
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = "Password";
        [Required]
        public UserRole Role { get; set; } = UserRole.Employee;
    }
}
