using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;
using WebStore.Interfaces;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route(WebApiAddresses.Products)]
    [ApiController]
    public class ProductsApiController : ControllerBase, IProductDataService
    {
        private readonly IProductDataService productDataService;

        public ProductsApiController(IProductDataService productDataService) => this.productDataService = productDataService;


        [HttpGet("sections")]
        public IEnumerable<Section> GetSections() => productDataService.GetSections();

        [HttpGet("brands")]
        public IEnumerable<BrandDTO> GetBrands() => productDataService.GetBrands();

        [HttpPost]
        public IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null) => productDataService.GetProducts(Filter);

        [HttpGet("{id}")]
        public ProductDTO GetProductById(int id) => productDataService.GetProductById(id);
    }
}
