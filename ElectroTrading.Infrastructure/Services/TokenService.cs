using ElectroTrading.Application.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly JWTConfiguration _configuration;
        public TokenService(IOptions<JWTConfiguration> config)
        {
            _configuration = config.Value;
        }

        public string GetAccessToken(Claim[] claims)
        {
            Claim[] jwtClaim = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Name, DateTime.UtcNow.ToString()),
            };

            var jwtCLaims = claims.Concat(jwtClaim);

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Secret)),
                SecurityAlgorithms.HmacSha256
            );


            var token = new JwtSecurityToken(
                _configuration.ValidIssuer,
                _configuration.ValidAudience,
                jwtCLaims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
                );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
