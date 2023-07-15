using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Models.ViewModels
{
    public class LoginViewModel
    {
        public string Token { get; set; } = string.Empty;
        public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;
        public string UserRole { get; set; } = string.Empty;
    }
}
