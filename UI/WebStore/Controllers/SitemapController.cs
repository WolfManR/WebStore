using Microsoft.AspNetCore.Mvc;

using SimpleMvcSitemap;

using System.Collections.Generic;
using System.Linq;

using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    public class SitemapController : Controller
    {
        public IActionResult Index([FromServices] IProductDataService productDataService)
        {
            var nodes = new List<SitemapNode>
            {
                new SitemapNode(Url.Action("Index", "Home")),
                new SitemapNode(Url.Action("Index", "Contact")),
                new SitemapNode(Url.Action("BlogList", "Blog")),
                new SitemapNode(Url.Action("BlogSingle", "Blog")),
                new SitemapNode(Url.Action("Products", "Shop")),
                new SitemapNode(Url.Action("Index", "WebApiTest")),
            };

            nodes.AddRange(productDataService.GetSections()
                .Select(section => new SitemapNode(Url.Action("Products", "Shop", new { SectionId = section.Id }))));

            nodes.AddRange(productDataService.GetBrands()
                .Select(brand => new SitemapNode(Url.Action("Products", "Shop", new {BrandId = brand.Id}))));

            nodes.AddRange(productDataService.GetProducts()
                .Products.Select(product => new SitemapNode(Url.Action("ProductDetails", "Shop", new {product.Id}))));

            return new SitemapProvider().CreateSitemap(new SitemapModel(nodes));
        }
    }
}
