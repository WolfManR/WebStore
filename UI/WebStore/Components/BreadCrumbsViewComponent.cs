using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.ViewModels;
using WebStore.Interfaces.Services;

namespace WebStore.Components
{
    public class BreadCrumbsViewComponent:ViewComponent
    {
        private readonly IProductDataService productDataService;

        public BreadCrumbsViewComponent(IProductDataService productDataService) => this.productDataService = productDataService;

        public IViewComponentResult Invoke()
        {
            var model = new BreadCrumbViewModel();

            if (int.TryParse(Request.Query["SectionId"].ToString(), out var sectionId))
                model.Section = productDataService.GetSection(sectionId);

            if (int.TryParse(Request.Query["BrandId"].ToString(), out var brandId))
                model.Brand = productDataService.GetBrand(brandId);

            if (int.TryParse(ViewContext.RouteData.Values["id"]?.ToString(), out var productId))
            {
                var product = productDataService.GetProductById(productId);
                if (product != null) model.Product = product.Name;
            }

            return View(model);
        }
    }
}