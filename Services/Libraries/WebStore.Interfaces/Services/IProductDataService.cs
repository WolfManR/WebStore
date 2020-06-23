using System.Collections.Generic;

using WebStore.Domain.Entities;

namespace WebStore.Interfaces.Services
{
    public interface IProductDataService
    {
        IEnumerable<Section> GetSections();
        IEnumerable<Brand> GetBrands();
        IEnumerable<Product> GetProducts(ProductFilter Filter = null);
        Product GetProductById(int id);
    }
}
