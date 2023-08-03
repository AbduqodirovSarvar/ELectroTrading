using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Services
{
    public static class MakeImageName
    {
        public static string GetName(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            string name = "IMG_" + Guid.NewGuid().ToString();
            return name + extension;
        }
    }
}
