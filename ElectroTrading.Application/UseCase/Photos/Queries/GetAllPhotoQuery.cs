using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Photos.Queries
{
    public class GetAllPhotoQuery : IQuery<List<PhotoViewModel>>
    {
        public GetAllPhotoQuery() { }
    }
}
