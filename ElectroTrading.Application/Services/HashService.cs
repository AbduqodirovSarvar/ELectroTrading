using ElectroTrading.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSystem.Security.Cryptography;

namespace ElectroTrading.Application.Services
{
    public class HashService : IHashService
    {
        public string GetHash(string password)
        {
            var sha256 = new SHA256Managed();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

    }
}
