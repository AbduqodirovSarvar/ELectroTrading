using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Storages.Queries
{
    public class GetAllProductStorageQuery : IQuery<List<StorageViewModel>>
    {
        public GetAllProductStorageQuery() { }
    }
}
