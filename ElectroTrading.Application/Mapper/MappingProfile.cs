using AutoMapper;
using ElectroTrading.Application.Models.DTOs;
using ElectroTrading.Application.Models.ViewModels;
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
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<EmployeeCreateCommand, Employee>();
            CreateMap<AttendanceCreateDto, Attendance>();
            CreateMap<Attendance, AttendanceViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<UserAddCommand, User>();
        }
    }
}
