using ElectroTrading.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public int UserId { get; set; }
        public CurrentUserService(IHttpContextAccessor _contextAccessor)
        {
            var userClaims = _contextAccessor.HttpContext!.User.Claims;
            var idClaim = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (idClaim != null && int.TryParse(idClaim.Value, out int value))
            {
                UserId = value;
            }
        }
    }
}
