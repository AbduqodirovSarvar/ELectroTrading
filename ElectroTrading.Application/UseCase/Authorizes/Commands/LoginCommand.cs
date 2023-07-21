using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Authorizes.Commands
{
    public class LoginCommand : ICommand<LoginViewModel>
    {
        public LoginCommand(string login, string password) 
        {
            Login = login;
            Password = password;
        }
        public LoginCommand() { }
        [Required]
        public string Login { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
