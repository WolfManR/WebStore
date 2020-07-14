using Microsoft.AspNetCore.Mvc;
using WebStore.Interfaces.Services;

namespace WebStore.Components
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartDataService cartService;

        public CartViewComponent(ICartDataService cartService) => this.cartService = cartService;

        public IViewComponentResult Invoke() => View(cartService.TransformFromCart());
    }
}