using Microsoft.AspNetCore.Mvc;

using System.Linq;

using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductDataService productDataService;
        public ShopController(IProductDataService productDataService)
        {
            this.productDataService = productDataService;
        }
        public IActionResult Home()
        {
            var products = productDataService.GetProducts();

            return View(new CatalogViewModel
            {
                Products = products.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl
                }).Take(6).OrderBy(p => p.Order)
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
                Products = products.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl
                }).OrderBy(p => p.Order)
            });
        }

        public IActionResult ProductDetails() => View();
        public IActionResult Checkout() => View();
        public IActionResult Cart() => View();
    }
}
