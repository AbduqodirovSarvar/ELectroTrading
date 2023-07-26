using AutoMapper;
using ElectroTrading.Application.Models.DTOs;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Orders.Commands;
using ElectroTrading.Application.UseCase.Salary.Commands;
using ElectroTrading.Application.UseCase.Users.Commands;
using ElectroTrading.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, User>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<CreateEmployeeCommand, Employee>().ReverseMap();
            CreateMap<AttendanceCreateDto, Attendance>().ReverseMap();
            CreateMap<Attendance, AttendanceViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
            CreateMap<CreateDebtCommand, EmployeeDebt>().ReverseMap();
            CreateMap<EmployeeDebt, DebtViewModel>().ReverseMap();
            CreateMap<CreateSalaryPaymentCommand, PaymentSalary>().ReverseMap();
            CreateMap<PaymentSalary, SalaryViewModel>().ReverseMap();
        }
    }
}
