using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using System.Linq;

using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels.Products;

namespace WebStore.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductDataService productDataService;
        private readonly IMapper mapper;

        public ShopController(IProductDataService productDataService, IMapper mapper)
        {
            this.productDataService = productDataService;
            this.mapper = mapper;
        }
        public IActionResult Home()
        {
            var products = productDataService.GetProducts();

            return View(new CatalogViewModel
            {
                Products = products.Take(6).Select(mapper.Map<ProductViewModel>).OrderBy(p => p.Order)
            });
        }

        public IActionResult Products(int? SectionId, int? BrandId)
        {
            var filter = new ProductFilter
            {
                SectionId = SectionId,
                BrandId = BrandId
            };

            var products = productDataService.GetProducts(filter);

            return View(new CatalogViewModel
            {
                SectionId = SectionId,
                BrandId = BrandId,
                Products = products.Select(mapper.Map<ProductViewModel>).OrderBy(p => p.Order)
            });
        }

        public IActionResult ProductDetails() => View();
        public IActionResult Checkout() => View();
        public IActionResult Cart() => View();
    }
}
