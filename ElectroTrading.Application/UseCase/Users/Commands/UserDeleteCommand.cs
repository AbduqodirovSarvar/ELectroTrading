using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElectroTrading.Application.UseCase.Users.Commands
{
    public class UserDeleteCommand : ICommand<UserViewModel>
    {
        public UserDeleteCommand(int id) 
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
