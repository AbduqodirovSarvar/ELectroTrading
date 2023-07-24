using ElectroTrading.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElectroTrading.Application.UseCase.Users.Commands
{
    public class DeleteUserCommand : ICommand<bool>
    {
        [Required]
        public int Id { get; set; }
    }
}
