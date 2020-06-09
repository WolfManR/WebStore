using AutoMapper;

using WebStore.Domain.Entities;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
