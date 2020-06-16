﻿using AutoMapper;

using WebStore.Domain.Entities;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ForMember(dest=>dest.Birthday,opt=>opt.MapFrom(src=>src.BirthdayDate));
            CreateMap<Employee, EmployeeViewModel>().ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.BirthdayDate)).ReverseMap();
        }
    }
}
