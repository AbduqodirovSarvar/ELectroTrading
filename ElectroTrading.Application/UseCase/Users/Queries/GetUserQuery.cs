using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Users.Queries
{
    public class GetUserQuery : IQuery<UserViewModel>
    {
        [Required]
        public int Id { get; set; }
    }
}
