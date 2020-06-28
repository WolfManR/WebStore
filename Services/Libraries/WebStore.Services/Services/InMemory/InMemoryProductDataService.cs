using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;

using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;
using WebStore.Services.Data;

namespace WebStore.Services.Services.InMemory
{
    [Obsolete("use SqlProductDataService", error: true)]
    public class InMemoryProductDataService : IProductDataService
    {
        private readonly IMapper mapper;

        public InMemoryProductDataService(IMapper mapper) => this.mapper = mapper;


        public IEnumerable<Section> GetSections() => TestData.Sections;
        public IEnumerable<BrandDTO> GetBrands() => TestData.Brands.Select(mapper.Map<BrandDTO>);

        public IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null)
        {
            var query = TestData.Products;

            if (Filter?.SectionId != null)
                query = query.Where(product => product.SectionId == Filter.SectionId);

            if (Filter?.BrandId != null)
                query = query.Where(product => product.BrandId == Filter.BrandId);

            return query.Select(mapper.Map<ProductDTO>);
        }

        public ProductDTO GetProductById(int id) => mapper.Map<ProductDTO>(TestData.Products.FirstOrDefault(p => p.Id == id));
    }
}
