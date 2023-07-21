using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Users.Commands
{
    public class UserUpdateCommand : ICommand<UserViewModel>
    {
        public UserUpdateCommand() { }
        public int UserId { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public UserRole? Role { get; set; }
    }
}
