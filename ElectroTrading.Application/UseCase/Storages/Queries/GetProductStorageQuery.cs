using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Storages.Queries
{
    public class GetProductStorageQuery : IQuery<StorageViewModel>
    {
        public GetProductStorageQuery(int id ) { Id = id; }
        [Required]
        public int Id { get; set; }
    }
}
