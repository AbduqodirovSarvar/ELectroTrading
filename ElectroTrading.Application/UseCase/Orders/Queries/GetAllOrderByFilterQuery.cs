using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Orders.Queries
{
    public class GetAllOrderByFilterQuery : IQuery<List<OrderViewModel>>
    {
        public GetAllOrderByFilterQuery() { }
        public bool? IsSubmitted { get; set; }

    }
}
