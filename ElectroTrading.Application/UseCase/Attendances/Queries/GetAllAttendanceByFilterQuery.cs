using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Attendances.Queries
{
    public class GetAllAttendanceByFilterQuery : IQuery<List<AttendanceViewModel>>
    {
        public int? EmployeeId { get; set; } = null;
        public int? Year { get; set; } = null;
        public int? Month { get; set; } = null;
        public int? Day { get; set; } = null;
    }
}
