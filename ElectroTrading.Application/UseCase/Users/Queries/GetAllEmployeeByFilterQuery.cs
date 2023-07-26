using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Users.Queries
{
    public class GetAllEmployeeByFilterQuery : IQuery<List<EmployeeViewModel>>
    {
        public GetAllEmployeeByFilterQuery() { }
        public DateOnly? Month { get; set; } = null;
    }
}
