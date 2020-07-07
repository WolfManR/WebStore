using AutoMapper;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using System.Collections.Generic;
using System.Linq;

using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;
using WebStore.Domain.Models;
using WebStore.Domain.ViewModels.Products;
using WebStore.Interfaces.Services;
using WebStore.Services.Services;

using Assert = Xunit.Assert;

namespace WebStore.Services.Tests.Services
{
    [TestClass]
    public class CartDataServiceTests
    {
        private Cart cart;

        private Mock<IProductDataService> productDataMock;
        private Mock<ICartRepo> cartStoreMock;
        private Mock<IMapper> mapperMock;
        private ICartDataService cartService;

        [TestInitialize]
        public void TestInitialize()
        {
            cart = new Cart
            {
                Items = new List<CartItem>
                {
                    new CartItem { ProductId = 1, Quantity = 1 },
                    new CartItem { ProductId = 2, Quantity = 3 }
                }
            };
            productDataMock = new Mock<IProductDataService>();
            productDataMock
               .Setup(c => c.GetProducts(It.IsAny<ProductFilter>()))
               .Returns(new List<ProductDTO>
                {
                    new ProductDTO
                    {
                        Id = 1,
                        Name = "Product 1",
                        Price = 1.1m,
                        Order = 0,
                        ImageUrl = "Product1.png",
                        Brand = new BrandDTO { Id = 1, Name = "Brand 1" },
                        Section = new SectionDTO { Id = 1, Name = "Section 1"}
                    },
                    new ProductDTO
                    {
                        Id = 2,
                        Name = "Product 2",
                        Price = 2.2m,
                        Order = 1,
                        ImageUrl = "Product2.png",
                        Brand = new BrandDTO { Id = 2, Name = "Brand 2" },
                        Section = new SectionDTO { Id = 2, Name = "Section 2"}
                    },
                });

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

            cartStoreMock = new Mock<ICartRepo>();
            cartStoreMock.Setup(c => c.Cart).Returns(cart);
            cartService = new CartDataService(productDataMock.Object, cartStoreMock.Object,mapperMock.Object);

        }

        [TestMethod]
        public void Cart_Class_ItemsCount_returns_Correct_Quantity()
        {
            const int expectedCount = 4;

            var actualCount = cart.ItemsCount;

            Assert.Equal(expectedCount, actualCount);
        }

        [TestMethod]
        public void CartViewModel_Returns_Correct_ItemsCount()
        {
            var cartViewModel = new CartViewModel
            {
                Items = new[]
                {
                    ( new ProductViewModel {Id = 1, Name = "Product 1", Price = 0.5m}, 1 ),
                    ( new ProductViewModel {Id = 2, Name = "Product 2", Price = 1.5m}, 3 ),
                }
            };
            const int expectedCount = 4;

            var actualCount = cartViewModel.ItemsCount;

            Assert.Equal(expectedCount, actualCount);
        }

        [TestMethod]
        public void CartService_AddToCart_WorkCorrect()
        {
            cart.Items.Clear();

            const int expectedId = 5;

            cartService.AddToCart(expectedId);

            Assert.Equal(1, cart.ItemsCount);

            Assert.Single(cart.Items);
            Assert.Equal(expectedId, cart.Items[0].ProductId);
        }

        [TestMethod]
        public void CartService_RemoveFromCart_Remove_Correct_Item()
        {
            const int itemId = 1;

            cartService.RemoveFromCart(itemId);

            Assert.Single(cart.Items);
            Assert.Equal(2, cart.Items[0].ProductId);
        }

        [TestMethod]
        public void CartService_RemoveAll_ClearCart()
        {
            cartService.RemoveAll();

            Assert.Empty(cart.Items);
        }

        [TestMethod]
        public void CartService_Decrement_Correct()
        {
            const int itemId = 2;

            cartService.DecrementFromCart(itemId);

            Assert.Equal(3, cart.ItemsCount);
            Assert.Equal(2, cart.Items.Count);
            Assert.Equal(itemId, cart.Items[1].ProductId);
            Assert.Equal(2, cart.Items[1].Quantity);
        }

        [TestMethod]
        public void CartService_Remove_Item_When_Decrement_to_0()
        {
            const int itemId = 1;

            cartService.DecrementFromCart(itemId);

            Assert.Equal(3, cart.ItemsCount);
            Assert.Single(cart.Items);
        }

        [TestMethod]
        public void CartService_TransformFromCart_WorkCorrect()
        {
            var result = cartService.TransformFromCart();

            Assert.Equal(4, result.ItemsCount);
            Assert.Equal(1.1m, result.Items.First().product.Price);
        }
    }
}