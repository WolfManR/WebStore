using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using System.Linq;
using Microsoft.Extensions.Configuration;
using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels;
using WebStore.Domain.ViewModels.Products;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductDataService productDataService;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public ShopController(IProductDataService productDataService, IMapper mapper, IConfiguration configuration)
        {
            this.productDataService = productDataService;
            this.mapper = mapper;
            this.configuration = configuration;
        }
        public IActionResult Home()
        {
            var products = productDataService.GetProducts();

            return View(new CatalogViewModel
            {
                Products = products.Products.Take(6).Select(mapper.Map<ProductViewModel>).OrderBy(p => p.Order)
            });
        }

        public IActionResult Products(int? SectionId, int? BrandId, int Page = 1)
        {
            var pageSize = int.TryParse(configuration["PageSize"], out var size) ? size : (int?)null;

            var filter = new ProductFilter
            {
                SectionId = SectionId,
                BrandId = BrandId,
                Page = Page,
                PageSize = pageSize
            };

            var products = productDataService.GetProducts(filter);

            return View(new CatalogViewModel
            {
                SectionId = SectionId,
                BrandId = BrandId,
                Products = products.Products.Select(mapper.Map<ProductViewModel>).OrderBy(p => p.Order),
                PageViewModel = new PageViewModel
                {
                    PageSize = pageSize??0,
                    PageNumber = Page,
                    TotalItems = products.TotalCount
                }
            });
        }

        public IActionResult ProductDetails(int id)
        {
            if (id == 0) return BadRequest();

            var product = productDataService.GetProductById(id);
            if (product is null) return NotFound();
            return View(mapper.Map<ProductViewModel>(product));
        }
    }
}
