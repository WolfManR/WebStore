using AutoMapper;

using System.Linq;

using WebStore.Domain.Entities;
using WebStore.Domain.Models;
using WebStore.Domain.ViewModels.Products;
using WebStore.Interfaces.Services;

namespace WebStore.Services.Services
{
    public class CartDataService : ICartDataService
    {
        private readonly IProductDataService dataService;
        private readonly ICartRepo cartRepo;
        private readonly IMapper mapper;

        public Cart Cart { get => cartRepo.Cart; set => cartRepo.Cart = value; }


        public CartDataService(IProductDataService productDataService, ICartRepo cartRepo, IMapper mapper)
        {
            dataService = productDataService;
            this.cartRepo = cartRepo;
            this.mapper = mapper;
        }


        #region ICartDataService reailization

        public void AddToCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item is null) cart.Items.Add(new CartItem { ProductId = id, Quantity = 1 });
            else item.Quantity++;

            Cart = cart;
        }

        public void DecrementFromCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item is null) return;

            if (item.Quantity > 0) item.Quantity--;
            if (item.Quantity == 0) cart.Items.Remove(item);

            Cart = cart;
        }

        public void RemoveAll()
        {
            var cart = Cart;
            cart.Items.Clear();
            Cart = cart;
        }

        public void RemoveFromCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item is null) return;
            cart.Items.Remove(item);

            Cart = cart;
        }

        public CartViewModel TransformFromCart()
        {
            var products = dataService.GetProducts(new ProductFilter
            {
                Ids = Cart.Items.Select(item => item.ProductId).ToArray()
            });

            var productViewModels = products.Products.Select(mapper.Map<ProductViewModel>).ToDictionary(p => p.Id);

            return new CartViewModel
            {
                Items = Cart.Items.Select(item => (productViewModels[item.ProductId], item.Quantity))
            };
        }
        #endregion
    }
}