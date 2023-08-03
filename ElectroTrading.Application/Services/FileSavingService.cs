using ElectroTrading.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Services
{
    public class FileSavingService
    {
       /* public async (string, string) SaveImage(IFormFile image)
        {
            string webRootPath = _env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            string filePath = Path.Combine(webRootPath, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return (fileName, filePath);
        }

        public string GetImagePath(string fileName)
        {
            string webRootPath = _env.WebRootPath;
            string filePath = Path.Combine(webRootPath, fileName);

            return filePath;
        }*/
    }
}
