using ElectroTrading.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ElectroTrading.Application.Services
{
    public class SendTelegramMessage : ISendTelegramMessage
    {
        public async Task<string> SendMessage(int chatId, string message)
        {
            TelegramBotClient botClient = new TelegramBotClient("5255513447:AAGe6QnkefU1VT9jNH8yj4S02OlUWBN0Hsk");
            await botClient.SendTextMessageAsync(chatId, "Hello, world!");

            return "Ok";
        }
    }
}
