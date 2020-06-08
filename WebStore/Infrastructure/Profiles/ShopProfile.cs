using AutoMapper;

using WebStore.Domain.Entities;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Profiles
{
    public class ShopProfile : Profile
    {
        public ShopProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Section, SectionViewModel>();
            CreateMap<Brand, BrandViewModel>();
        }
    }
}
