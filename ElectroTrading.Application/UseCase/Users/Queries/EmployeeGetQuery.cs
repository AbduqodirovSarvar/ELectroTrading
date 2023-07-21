using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Users.Queries
{
    public class EmployeeGetQuery : IQuery<EmployeeViewModel>
    {
        public EmployeeGetQuery(int id) { Id = id; }
        public int Id { get; set; }
    }
}
