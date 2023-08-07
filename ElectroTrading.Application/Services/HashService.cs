using ElectroTrading.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ElectroTrading.Application.Services
{
    public class HashService : IHashService
    {
        public string GetHash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                string hash = Convert.ToBase64String(hashBytes);
                return hash;
            }
        }
    }
}
