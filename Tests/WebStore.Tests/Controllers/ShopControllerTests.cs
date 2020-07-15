using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using System.Collections.Generic;
using System.Linq;

using WebStore.Controllers;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels.Products;
using WebStore.Interfaces.Services;

using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class ShopControllerTests
    {
        private readonly ProductDTO[] products = {
            new ProductDTO
            {
                Id = 1,
                Name = "Product 1",
                Order = 0,
                Price = 10m,
                ImageUrl = "Product1.png",
                Brand = new BrandDTO
                {
                    Id = 1,
                    Name = "Brand of product 1"
                },
                Section = new SectionDTO
                {
                    Id = 1,
                    Name = "Section of product 1"
                }
            },
            new ProductDTO
            {
                Id = 2,
                Name = "Product 2",
                Order = 1,
                Price = 20m,
                ImageUrl = "Product2.png",
                Brand = new BrandDTO
                {
                    Id = 2,
                    Name = "Brand of product 2"
                },
                Section = new SectionDTO
                {
                    Id = 2,
                    Name = "Section of product 2"
                }
            },
        };

        private Mock<IProductDataService> productDataMock;
        private Mock<IMapper> mapperMock;


        [TestInitialize]
        public void TestInitialize()
        {
            productDataMock = new Mock<IProductDataService>();
            productDataMock.Setup(p => p.GetProducts(It.IsAny<ProductFilter>())).Returns(new PageProductsDTO
            {
                Products = products,
                TotalCount = products.Length
            });
            productDataMock.Setup(p => p.GetProductById(It.IsAny<int>()))
                .Returns<int>(id => products.FirstOrDefault(product=>product.Id==id));



            mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<ProductViewModel>(It.IsAny<ProductDTO>()))
                .Returns<ProductDTO>(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price,
                    Brand = p.Brand?.Name,
                    ImageUrl = p.ImageUrl
                });
        }

        [TestMethod]
        public void Details_Returns_With_Correct_View()
        {
            // A - A - A == Arrange - Act - Assert == Preparation of data and test object - action on an object - verification of claims

            #region Arrange

            const int expectedProductId = 1;
            const decimal expectedPrice = 10m;

            var expectedName = $"Product {expectedProductId}";
            var expectedBrandName = $"Brand of product {expectedProductId}";

            var controller = new ShopController(productDataMock.Object, mapperMock.Object);

            #endregion

            #region Act

            var result = controller.ProductDetails(expectedProductId);

            #endregion

            #region Assert

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ProductViewModel>(viewResult.Model);

            Assert.Equal(expectedProductId, model.Id);
            Assert.Equal(expectedName, model.Name);
            Assert.Equal(expectedPrice, model.Price);
            Assert.Equal(expectedBrandName, model.Brand);

            #endregion
        }

        [TestMethod]
        public void Shop_Returns_Correct_View()
        {
            var controller = new ShopController(productDataMock.Object, mapperMock.Object);

            const int expectedSectionId = 1;
            const int expectedBrandId = 5;

            var result = controller.Products(expectedSectionId, expectedBrandId);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CatalogViewModel>(viewResult.ViewData.Model);

            Assert.Equal(products.Count(), model.Products.Count());
            Assert.Equal(expectedBrandId, model.BrandId);
            Assert.Equal(expectedSectionId, model.SectionId);

            Assert.Equal(products[0].Brand.Name, model.Products.First().Brand);
        }
    }
}