﻿using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;

using WebStore.Domain.ViewModels.Products;
using WebStore.Interfaces.Services;

namespace WebStore.Components
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductDataService productDataService;
        private readonly IMapper mapper;

        public BrandsViewComponent(IProductDataService productDataService, IMapper mapper)
        {
            this.productDataService = productDataService;
            this.mapper = mapper;
        }

        public IViewComponentResult Invoke(string brandId) =>
            View(new SelectableBrandsViewModel
            {
                Brands = GetBrands(),
                CurrentBrandId = int.TryParse(brandId,out var id)?id:(int?)null
            });

        private IEnumerable<BrandViewModel> GetBrands() => productDataService.GetBrands()
               .Select(mapper.Map<BrandViewModel>);
    }
}
