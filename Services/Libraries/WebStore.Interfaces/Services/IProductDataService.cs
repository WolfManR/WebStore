using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;

namespace WebStore.Interfaces.Services
{
    public interface IProductDataService
    {
        IEnumerable<Section> GetSections();
        IEnumerable<BrandDTO> GetBrands();
        IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null);
        ProductDTO GetProductById(int id);

        Section GetSection(int id) => GetSections().FirstOrDefault(s => s.Id == id);
        BrandDTO GetBrand(int id) => GetBrands().FirstOrDefault(b => b.Id == id);
    }
}
