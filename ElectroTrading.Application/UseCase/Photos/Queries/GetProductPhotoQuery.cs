using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.UseCase.Photos.QueryHandlers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Photos.Queries
{
    public class GetProductPhotoQuery : IQuery<PhotoFile>
    {
        public GetProductPhotoQuery(int id) { ProductId = id; }
        [Required]
        public int ProductId { get; set; }
    }
}
