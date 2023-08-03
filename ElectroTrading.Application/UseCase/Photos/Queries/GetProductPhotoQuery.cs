using ElectroTrading.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Photos.Queries
{
    public class GetProductPhotoQuery : IQuery<(string, string)>
    {
        public GetProductPhotoQuery(int id) { Id = id; }
        [Required]
        public int Id { get; set; }
    }
}
