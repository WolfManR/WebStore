using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Net.Http;

using WebStore.Clients.Base;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;
using WebStore.Interfaces;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Products
{
    public class ProductsClient : BaseClient, IProductDataService
    {
        public ProductsClient(IConfiguration configuration) : base(configuration, WebApiAddresses.Products) {}


        public IEnumerable<Section> GetSections() => Get<IEnumerable<Section>>($"{ServiceAddress}/sections");

        public IEnumerable<BrandDTO> GetBrands() => Get<IEnumerable<BrandDTO>>($"{ServiceAddress}/brands");

        public PageProductsDTO GetProducts(ProductFilter Filter = null) =>
            Post(ServiceAddress, Filter ?? new ProductFilter())
                .Content
                .ReadAsAsync<PageProductsDTO>()
                .Result;

        public ProductDTO GetProductById(int id) => Get<ProductDTO>($"{ServiceAddress}/{id}");
    }
}