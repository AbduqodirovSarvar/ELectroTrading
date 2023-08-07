using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Mapper;
using ElectroTrading.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ElectroTrading.Application
{
    public static class DepencyInjection
    {
        public static IServiceCollection ApplicationService(this IServiceCollection _services, IConfiguration _configuration)
        {
            _services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DepencyInjection).Assembly);
            });
            _services.AddScoped<ICurrentUserService, CurrentUserService>();
            _services.AddScoped<IHashService, HashService>();
            _services.AddScoped<ISendTelegramMessage, SendTelegramMessage>();
            _services.AddScoped<ITelegramBotClient>(x => 
            {
                var token = _configuration.GetSection("TelegramBot:Token").Value;
                if (token == null)
                {
                    throw new ArgumentNullException("Bot token", nameof(token));
                }
                return new TelegramBotClient(token);
            });

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
