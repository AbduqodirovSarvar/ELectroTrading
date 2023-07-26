using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Salary.Queries
{
    public class GetAllSalaryByFilterQuery : IQuery<List<SalaryViewModel>>
    {
        public GetAllSalaryByFilterQuery() { }
        public int? EmployeeId { get; set; } = null;
        public DateOnly? Date { get; set; } = null;
    }
}
