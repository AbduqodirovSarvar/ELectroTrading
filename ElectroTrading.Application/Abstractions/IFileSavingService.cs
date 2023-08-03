using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Abstractions
{
    public interface IFileSavingService
    {
        string GetImagePath(string fileName);

        (string, string) SaveImage(IFormFile image);
    }
}
