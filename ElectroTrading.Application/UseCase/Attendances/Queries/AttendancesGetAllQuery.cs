using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Attendances.Queries
{
    public class AttendancesGetAllQuery : IQuery<List<AttendanceViewModel>>
    {
        public AttendancesGetAllQuery() { }
    }
}
