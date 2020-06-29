using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;

using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Identity;
using WebStore.Interfaces.Services;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.Administrator)]
    public class CatalogController : Controller
    {
        private readonly IProductDataService productDataService;
        private readonly IMapper mapper;

        public CatalogController(IProductDataService productDataService, IMapper mapper)
        {
            this.productDataService = productDataService;
            this.mapper = mapper;
        }

        public IActionResult Index() => View(productDataService.GetProducts().Select(mapper.Map<Product>));

        public IActionResult Edit(int? id)
        {
            var product = id is null ? new Product() : mapper.Map<Product>(productDataService.GetProductById((int)id));

            if (product is null) return NotFound();
            return View(product);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Product product) => RedirectToAction(nameof(Index));

        public IActionResult Delete(int? id)
        {
            _ = id ?? throw new ArgumentNullException(nameof(id));
            if (id <= 0) return BadRequest();

            var product = productDataService.GetProductById((int)id);

            if (product is null) return NotFound();
            return View(mapper.Map<Product>(product));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id) => RedirectToAction(nameof(Index));
    }
}
