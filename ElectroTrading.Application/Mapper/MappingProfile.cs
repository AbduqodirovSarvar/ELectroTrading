using AutoMapper;
using ElectroTrading.Application.Models.DTOs;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Attendances.Commands;
using ElectroTrading.Application.UseCase.BSProducts.Commands;
using ElectroTrading.Application.UseCase.FinishedProducts.Commands;
using ElectroTrading.Application.UseCase.Orders.Commands;
using ElectroTrading.Application.UseCase.ProductCompositions.Commands;
using ElectroTrading.Application.UseCase.Products.Commands;
using ElectroTrading.Application.UseCase.Salary.Commands;
using ElectroTrading.Application.UseCase.Storages.Commands;
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
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<Product, ProductViewModel>()
                .ForMember(x => x.TotalCompPrice, y => y.MapFrom(z => z.Compositions.Sum(sum => Convert.ToDecimal(sum.Amount) * sum.Composition.Price)));
            CreateMap<CreateFinishedProductCommand, FinishedProduct>().ReverseMap();
            CreateMap<FinishedProduct, FinishedProductViewModel>()
                .ForMember(dest => dest.Desciption, opt => opt.MapFrom(src => src.Description)).ReverseMap();
            CreateMap<Comp, ProductComposition>().ReverseMap();
            CreateMap<ProductComposition, ProductCompositionViewModel>()
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Composition.Price))
                    .ForMember(x => x.CompositionName, y => y.MapFrom(z => z.Composition.Name));
            CreateMap<CreateBSProductCommand, BoughtAndSoldProduct>().ReverseMap();
            CreateMap<AddProductStorageCommand, Storage>().ReverseMap();
            CreateMap<ProductPhoto, PhotoViewModel>().ReverseMap();
            CreateMap<CreateAttendanceCommand, Attendance>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Storage, StorageViewModel>().ReverseMap();
            CreateMap<BoughtAndSoldProduct, BSProductViewModel>()
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => Convert.ToDecimal(src.Amount) * src.Price))
                    .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product));
        }
    }
}
