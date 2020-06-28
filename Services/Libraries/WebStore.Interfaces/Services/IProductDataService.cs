using System.Collections.Generic;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;

namespace WebStore.Interfaces.Services
{
    public interface IProductDataService
    {
        IEnumerable<Section> GetSections();
        IEnumerable<Brand> GetBrands();
        IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null);
        ProductDTO GetProductById(int id);
    }
}
