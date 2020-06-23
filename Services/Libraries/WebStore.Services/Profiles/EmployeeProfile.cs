using AutoMapper;

using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels;

namespace WebStore.Services.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.BirthdayDate)).ReverseMap();
        }
    }
}
