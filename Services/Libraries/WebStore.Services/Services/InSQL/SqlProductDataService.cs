using AutoMapper;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

using WebStore.DAL.Context;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;

namespace WebStore.Services.Services.InSQL
{
    public class SqlProductDataService : IProductDataService
    {
        private readonly WebStoreDB db;
        private readonly IMapper mapper;

        public SqlProductDataService(WebStoreDB db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public IEnumerable<Section> GetSections() => db.Sections;
        public IEnumerable<Brand> GetBrands() => db.Brands.Include(b=>b.Products);

        public IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null)
        {
            IQueryable<Product> query = db.Products;

            if (Filter?.BrandId != null)
                query = query.Where(product => product.BrandId == Filter.BrandId);

            if (Filter?.SectionId != null)
                query = query.Where(product => product.SectionId == Filter.SectionId);

            return query.AsEnumerable().Select(mapper.Map<ProductDTO>);
        }

        public ProductDTO GetProductById(int id) => mapper.Map<ProductDTO>(db.Products.Include(p => p.Section).Include(p => p.Brand).FirstOrDefault(p => p.Id == id));
    }
}
