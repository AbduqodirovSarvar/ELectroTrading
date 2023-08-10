using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Products.Queries
{
    public class GetAllProductByFilterQuery : IQuery<List<ProductViewModel>>
    {
        public GetAllProductByFilterQuery() { }
        public CategoryUnity? Category { get; set; } = null;
        public bool? isFinished { get; set; } = null;
        public bool? isOnSale { get; set;} = null;

    }
}
