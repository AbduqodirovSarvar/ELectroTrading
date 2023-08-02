using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Domain.Entities;
using ElectroTrading.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.BSProducts.Queries
{
    public class GetAllBSProductByFilterQuery : IQuery<List<BSProductViewModel>>
    {
        public GetAllBSProductByFilterQuery() { }
        public int? ProductId { get; set; } = null;
        public CategoryProcess? Category { get; set; } = null;
    }
}
