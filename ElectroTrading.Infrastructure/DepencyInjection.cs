using ElectroTrading.Application.Abstractions;
using ElectroTrading.Infrastructure.DbContexts;
using ElectroTrading.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Infrastructure
{
    public static class DepencyInjection
    {
        public static IServiceCollection InfrasturctureServices(this IServiceCollection _services, IConfiguration _config)
        {
            _services.AddDbContextFactory<AppDbContext>(opt => opt.UseNpgsql(_config.GetConnectionString("DefaultConnection")));

           /* _services.AddDbContext<AppDbContext>(options
                => options.UseNpgsql(_config.GetConnectionString("DefaultConnection")));*/

            _services.AddScoped<IAppDbContext, AppDbContext>();
            _services.AddScoped<ITokenService, TokenService>();

            _services.Configure<JWTConfiguration>(_config.GetSection("JWTConfiguration"));

            _services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = _config["JWTConfiguration:ValidAudience"],
                        ValidIssuer = _config["JWTConfiguration:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTConfiguration:Secret"]))
                    };
                });

            _services.AddAuthorization(option =>
            {
                option.AddPolicy("AdminActions", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Admin");
                });

                option.AddPolicy("OwnerActions", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Owner");
                });

                option.AddPolicy("MasterActions", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Master");
                });
            });
            return _services;
        }
    }
}
