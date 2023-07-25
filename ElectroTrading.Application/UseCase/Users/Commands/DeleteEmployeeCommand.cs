using ElectroTrading.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Users.Commands
{
    public class DeleteEmployeeCommand : ICommand<bool>
    {
        public DeleteEmployeeCommand(int id) { Id = id; }
        [Required]
        public int Id { get; set; }
    }
}
