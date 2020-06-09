using AutoMapper;

using WebStore.Domain.Entities;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        }
    }
}
