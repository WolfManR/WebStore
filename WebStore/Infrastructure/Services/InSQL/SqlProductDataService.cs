﻿using System.Collections.Generic;
using System.Linq;

using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services.InSQL
{
    public class SqlProductDataService : IProductDataService
    {
        private readonly WebStoreDB db;

        public SqlProductDataService(WebStoreDB db) => this.db = db;
        public IEnumerable<Section> GetSections() => db.Sections;
        public IEnumerable<Brand> GetBrands() => db.Brands;

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            IQueryable<Product> query = db.Products;

            if (Filter?.BrandId != null)
                query = query.Where(product => product.BrandId == Filter.BrandId);

            if (Filter?.SectionId != null)
                query = query.Where(product => product.SectionId == Filter.SectionId);

            return query;
        }
    }
}