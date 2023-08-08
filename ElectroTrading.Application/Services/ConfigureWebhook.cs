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
        private readonly ITelegramBotClient _botClient;

        public ConfigureWebhook(ILogger<ConfigureWebhook> logger, ITelegramBotClient botClient)
        {
            _logger = logger;
            _botClient = botClient;
        }

        public  Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Running...");
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _botClient.SendTextMessageAsync(chatId: 636809820, text: "Web Project is sleeping...", cancellationToken: cancellationToken);

            _logger.LogInformation("Sleeping !");
        }
    }
}
