using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Mapper;
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
            _services.AddScoped<IHashService, HashService>();
            _services.AddScoped<IUpdatePhoneNumber, UpdatePhoneNumber>();

            var mappingconfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingconfig.CreateMapper();
            _services.AddSingleton(mapper);

            return _services;
        }
    }
}
