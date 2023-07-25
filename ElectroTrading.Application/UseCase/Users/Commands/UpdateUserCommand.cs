using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElectroTrading.Application.UseCase.Users.Commands
{
    public class UpdateUserCommand : ICommand<UserViewModel>
    {
        [Required]
        public int Id { get; set; }
        public string? Phone { get; set; } = null;
        public string? Password { get; set; } = null;
        public UserRole? Role { get; set; } = null;
    }
}
