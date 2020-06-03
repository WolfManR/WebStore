using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;

using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Components
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductDataService productDataService;
        public BrandsViewComponent(IProductDataService productDataService)
        {
            this.productDataService = productDataService;
        }

        public IViewComponentResult Invoke() => View(GetBrands());

        private IEnumerable<BrandViewModel> GetBrands() => productDataService.GetBrands()
               .Select(brand => new BrandViewModel
               {
                   Id = brand.Id,
                   Name = brand.Name,
                   Order = brand.Order
               })
               .OrderBy(brand => brand.Order);
    }
}
