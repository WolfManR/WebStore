using System;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Identity;
using WebStore.Interfaces.Services;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.Administrator)]
    public class CatalogController : Controller
    {
        private readonly IProductDataService productDataService;

        public CatalogController(IProductDataService productDataService) => this.productDataService = productDataService;
        public IActionResult Index() => View(productDataService.GetProducts());

        public IActionResult Edit(int? id)
        {
            var product = id is null ? new Product() : productDataService.GetProductById((int)id);

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
            return View(product);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id) => RedirectToAction(nameof(Index));
    }
}
