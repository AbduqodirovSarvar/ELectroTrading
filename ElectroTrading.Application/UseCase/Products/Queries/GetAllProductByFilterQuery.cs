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
        public string? Name { get; set; } = null;
        public decimal? Price { get; set; } = null;
        public CategoryUnity? Category { get; set; } = null;

    }
}
