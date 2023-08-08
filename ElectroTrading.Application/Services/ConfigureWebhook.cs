using ElectroTrading.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ElectroTrading.Application.Services
{
    public class ConfigureWebhook : IHostedService
    {
        private readonly ILogger<ConfigureWebhook> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ConfigureWebhook(ILogger<ConfigureWebhook> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var _botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();

            await _botClient.SendTextMessageAsync(chatId: 636809820, text: "Web Project is running...", cancellationToken: cancellationToken);

            _logger.LogInformation("Running...");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var _botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();

            await _botClient.SendTextMessageAsync(chatId: 636809820, text: "Web Project stopped", cancellationToken: cancellationToken);

            _logger.LogInformation("Stopped !");
        }
    }
}
