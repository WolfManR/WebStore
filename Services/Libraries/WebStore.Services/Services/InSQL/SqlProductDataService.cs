﻿using AutoMapper;

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
        public IEnumerable<BrandDTO> GetBrands() => mapper.ProjectTo<BrandDTO>(db.Brands.OrderBy(b => b.Order));

        public PageProductsDTO GetProducts(ProductFilter Filter = null)
        {
            IQueryable<Product> query = db.Products;

            if (Filter?.Ids?.ToArray().Length > 0) query = query.Where(product => Filter.Ids.Contains(product.Id));
            else
            {
                if (Filter?.BrandId != null)
                    query = query.Where(product => product.BrandId == Filter.BrandId);
                if (Filter?.SectionId != null)
                    query = query.Where(product => product.SectionId == Filter.SectionId);
            }



            var totalCount = query.Count();

            if (Filter?.PageSize > 0)
                query = query.Skip((Filter.Page - 1) * (int)Filter.PageSize).Take((int)Filter.PageSize);

            return new PageProductsDTO
            {
                Products = mapper.ProjectTo<ProductDTO>(query),
                TotalCount = totalCount
            };
        }

        public ProductDTO GetProductById(int id) => 
            mapper.Map<ProductDTO>(
                db.Products
                    .Include(p => p.Section)
                    .Include(p => p.Brand)
                    .FirstOrDefault(p => p.Id == id)
                );
    }
}
