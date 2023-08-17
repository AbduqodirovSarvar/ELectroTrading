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
    public class GetAllDebtByFilterQuery : IQuery<DebtListViewModel>
    {
        public GetAllDebtByFilterQuery() { }
        public int? EmployeeId { get; set; } = null;
        public DateOnly? Date { get; set; } = null;
    }
}
