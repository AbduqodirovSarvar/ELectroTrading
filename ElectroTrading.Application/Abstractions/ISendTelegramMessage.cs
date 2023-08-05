using ElectroTrading.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Abstractions
{
    public interface ISendTelegramMessage
    {
        public Task<string> SendMessage(string message);
        public Task<string> MakeAttendanceText(List<AttendanceViewModel> attendances);
        public Task<string> MakeOrdertext(OrderViewModel orderView);
        public Task<string> MakeUpdateOrdertext(OrderViewModel orderView);
        public Task<string> MakeBSProductText(BSProductViewModel productView);
        public Task<string> MakeFinishedProduct(FinishedProductViewModel finishedProductView);
        public Task<string> MakeSalaryText(SalaryViewModel salaryView);
        public Task<string> MakeIndebtText(DebtViewModel debtView);
    }
}
