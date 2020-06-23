using AutoMapper;

using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels.Products;

namespace WebStore.Services.Profiles
{
    public class ShopProfile : Profile
    {
        public ShopProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Section, SectionViewModel>();
            CreateMap<Brand, BrandViewModel>().ForMember(dest => dest.ProductsCount, opt => opt.MapFrom(src => src.Products.Count));
        }
    }
}
