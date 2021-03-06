﻿using AutoMapper;

using WebStore.Domain.DTO.Order;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Orders;
using WebStore.Domain.ViewModels.Products;

namespace WebStore.Services.Profiles
{
    public class ShopProfile : Profile
    {
        public ShopProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductDTO, ProductViewModel>().ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name)).ReverseMap();

            CreateMap<Section, SectionViewModel>();
            CreateMap<Section, SectionDTO>();

            CreateMap<Brand, BrandViewModel>();
            CreateMap<BrandDTO, BrandViewModel>().ReverseMap();
            CreateMap<Brand, BrandDTO>().ForMember(dest => dest.ProductsCount, opt => opt.MapFrom(src => src.Products.Count)).ReverseMap();

            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
        }
    }
}
