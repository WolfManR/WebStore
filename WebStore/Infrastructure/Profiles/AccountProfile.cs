using AutoMapper;

using WebStore.Domain.Entities;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountViewModel>();
            CreateMap<Account, AccountViewModel>().ReverseMap();
        }
    }
}
