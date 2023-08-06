﻿using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace ElectroTrading.Application.Services
{
    public class SendTelegramMessage : ISendTelegramMessage
    {
        private readonly IAppDbContext _context;
        private readonly IConfiguration _configuration;
        public SendTelegramMessage(IAppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public Task<string> MakeAttendanceText(List<AttendanceViewModel> attendances)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("<b>🚶‍♂️ Yo'qlama :</b>\n\n");
            foreach(var att in attendances)
            {
                msg.Append("<b>" + att.LastName.ToString() + " " + att.FirstName.ToString() + "</b>"+ "\n👷 Lavozimi : " + att.Position.ToString() + "\n☀️ Asosiy ish : ");
                if(att.IsMainWork)
                {
                    msg.Append("✅\n");
                }
                else
                {
                    msg.Append("❌\n");
                }
                msg.Append("🕛 Kechikish vaqti : " + att.LateHours.ToString() + " soat\n");
                msg.Append("⏳ Qo'shimcha ish vaqti : " + att.ExtraWorkHours.ToString() + " soat\n");
                msg.Append("📅 Sana uchun : " + att.Day.ToString() + "\n\n\n");
            } 

            var user = _context.Users.FirstOrDefault(x => x.Id == attendances.First().ByWhomId);
            if (user == null)
            {
                throw new NotFoundException();
            }
            msg.Append("⌚️ Kiritilgan vaqt : " + attendances.First().CreatedDate.ToString() + "\n" + "👨‍✈️ Kim belgiladi : " + user.Phone.ToString());

            return Task.FromResult(msg.ToString());

        }

        public Task<string> MakeBSProductText(BSProductViewModel productView)
        {
            if (productView.Product == null)
            {
                throw new ArgumentNullException("BSProduct", "is null");
            }
            StringBuilder msg = new StringBuilder();
            if (productView.Category == Domain.Enum.CategoryProcess.Bought)
            {
                msg.Append("<b>📥 Sotib olindi :</b>\r\n\r\n🛠 Mahsulot nomi : ");
            }
            else
            {
                msg.Append("<b>📤 Sotildi :</b>\r\n\r\n🛠 Mahsulot nomi : ");
            }
            msg.Append(productView.Product.Name.ToString() + "\r\n⚖️ Miqdori : " + productView.Amount.ToString());
            msg.Append(" " + productView.Product.Category.ToString() + "\r\n💰 Narxi : " + productView.Price.ToString() + "\r\n💵 Umumiy narxi : " + productView.TotalPrice.ToString() + "\r\n📅 Sana : ");
            msg.Append(productView.CreatedDate.ToString() + "\r\n");

            return Task.FromResult(msg.ToString());
        }

        public Task<string> MakeFinishedProduct(FinishedProductViewModel finishedProductView)
        {
            if (finishedProductView.Product == null)
            {
                throw new ArgumentNullException("Finished Product", "product");
            }
            StringBuilder msg = new StringBuilder();
            msg.Append("<b>📦 Mahsulot tayyor bo'ldi :</b>\n\n🛠 Mahsulot nomi : " + finishedProductView.Product.Name.ToString() + "\n⚖️ Miqdori : " + finishedProductView.Amount.ToString());
            msg.Append(finishedProductView.Product.Category.ToString() + "\n");

            return Task.FromResult(msg.ToString());
        }

        public Task<string> MakeIndebtText(DebtViewModel debtView)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == debtView.ByWhomId);
            if (user == null || debtView.Employee == null)
                throw new NotFoundException();

            StringBuilder msg = new StringBuilder();
            msg.Append("<b>💸 Avans Berildi :</b>\r\n\r\n" + "<b>👨‍🔧 " + debtView.Employee.LastName.ToString() + " " + debtView.Employee.Name.ToString() + " : </b>" + debtView.Summs.ToString());
            msg.Append("\r\n\\🧾 Tavsifi : " + debtView.Description.ToString() + "\r\n👨‍✈️ Kim berdi : " + user.Phone.ToString() + "\n");

            return Task.FromResult(msg.ToString());
        }

        public Task<string> MakeOrdertext(OrderViewModel orderView)
        {
            if (orderView == null || orderView.Product == null)
            {
                throw new ArgumentNullException("Order Product", nameof(orderView.Product));
            }

            StringBuilder msg = new StringBuilder();

            msg.Append("<b>🗳 Buyurtma qo'shildi :</b>\n\n🛠 Mahsulot nomi : " + orderView.Product.Name.ToString() + "\n🧾 Tavsifi : " + orderView.Description.ToString() + "\n⚖️ Miqdori : " + orderView.Amount.ToString() + " " + orderView.Product.Category.ToString() + "\n");
            msg.Append("💰 Narxi :" + orderView.Price.ToString() + "\n📅 Muddati : " + orderView.DeadLine.ToString() + "\n" + "📊 Status : ");
            if (orderView.IsSubmitted)
            {
                msg.Append("✅\n");
            }
            else
            {
                msg.Append("⏳\n");
            }

            return Task.FromResult(msg.ToString());
        }

        public Task<string> MakeSalaryText(SalaryViewModel salaryView)
        {
            if(salaryView.Employee== null)
            {
                throw new ArgumentNullException("Employee", "needn't not null");
            }
            StringBuilder msg = new StringBuilder();

            msg.Append("<b>💸 Oylik berildi :</b> \n" + "<b>👨‍🔧 " + salaryView.Employee.LastName.ToString() + " " + salaryView.Employee.Name.ToString() + " :</b> " + salaryView.Summs.ToString() + "\n");
            var user = _context.Users.FirstOrDefault(x => x.Id == salaryView.EmployeeId);
            if(user == null)
            {
                throw new NotFoundException();
            }
            msg.Append("👨‍✈️ Kim berdi : " + user.Phone.ToString());

            return Task.FromResult(msg.ToString());
        }

        public Task<string> MakeUpdateOrdertext(OrderViewModel orderView)
        {
            if (orderView == null || orderView.Product == null)
            {
                throw new ArgumentNullException("Order Product", nameof(orderView.Product));
            }

            StringBuilder msg = new StringBuilder();

            msg.Append("<b>🗳 Buyurtma o'zgartirildi :</b>\n\n🛠 Mahsulot nomi : " + orderView.Product.Name.ToString() + "\n🧾 Tavsifi : " + orderView.Description.ToString() + "\n⚖️ Miqdori : " + orderView.Amount.ToString() + " " + orderView.Product.Category.ToString() + "\n");
            msg.Append("💰 Narxi :" + orderView.Price.ToString() + "\n📅 Muddati : " + orderView.DeadLine.ToString() + "\n" + " 📊 Status : ");
            if(orderView.IsSubmitted)
            {
                msg.Append("✅\n");
            }
            else
            {
                msg.Append("⏳\n");
            }

            return Task.FromResult(msg.ToString());
        }

        public async Task<string> SendMessage(string message)
        {
            var token = _configuration.GetSection("TelegramBot:Token").Value;
            if (token == null || token.Length <= 1)
            {
                throw new ArgumentNullException("Telegram bot", nameof(token));
            }
            TelegramBotClient botClient = new TelegramBotClient(token);

            var stringIds = _configuration.GetSection("TelegramBot:UserIds").Value;

            if(stringIds == null || stringIds.Length == 0)
            {
                throw new ArgumentNullException("Telegram users", nameof(stringIds));
            }

            List<int> chatIds = stringIds.Split(',').Select(int.Parse).ToList();
            
            foreach (int chatId in chatIds)
            {
                try
                {
                    await botClient.SendTextMessageAsync(chatId, message, parseMode: ParseMode.Html);
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message.ToString());
                    continue;
                }
            }

            return $"{chatIds.Count} ta telegram foydalanuvchiga bot tomonidan xabar jo'natildi";
        }
    }
}
