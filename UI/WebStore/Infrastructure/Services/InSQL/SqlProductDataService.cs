using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;

namespace WebStore.Infrastructure.Services.InSQL
{
    public class SqlProductDataService : IProductDataService
    {
        private readonly WebStoreDB db;

        public SqlProductDataService(WebStoreDB db) => this.db = db;
        public IEnumerable<Section> GetSections() => db.Sections;
        public IEnumerable<Brand> GetBrands() => db.Brands.Include(b=>b.Products);

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            IQueryable<Product> query = db.Products;

            if (Filter?.BrandId != null)
                query = query.Where(product => product.BrandId == Filter.BrandId);

            if (Filter?.SectionId != null)
                query = query.Where(product => product.SectionId == Filter.SectionId);

            return query;
        }

        public Product GetProductById(int id) => db.Products.Include(p => p.Section).Include(p => p.Brand).FirstOrDefault(p => p.Id == id);
    }
}
