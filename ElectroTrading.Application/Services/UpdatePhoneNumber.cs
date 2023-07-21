using ElectroTrading.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Services
{
    public class UpdatePhoneNumber : IUpdatePhoneNumber
    {
        public bool IsPermission(string phone)
        {
            return true;
        }
    }
}
