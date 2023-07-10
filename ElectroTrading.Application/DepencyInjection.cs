using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application
{
    public static class DepencyInjection
    {
        public static IServiceCollection ApplicationService(this IServiceCollection _services)
        {
            _services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DepencyInjection).Assembly);
            });
            _services.AddScoped<ICurrentUserService, CurrentUserService>();
            return _services;
        }
    }
}
