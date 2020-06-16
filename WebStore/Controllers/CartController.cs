using Microsoft.AspNetCore.Mvc;

using WebStore.Infrastructure.Interfaces;

namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartDataService cartService;

        public CartController(ICartDataService CartService) => cartService = CartService;

        public IActionResult Details() => View(cartService.TransformFromCart());

        public IActionResult AddToCart(int id)
        {
            cartService.AddToCart(id);
            return RedirectToAction(nameof(Details));
        }

        public IActionResult DecrementFromCart(int id)
        {
            cartService.DecrementFromCart(id);
            return RedirectToAction(nameof(Details));
        }

        public IActionResult RemoveFromCart(int id)
        {
            cartService.RemoveFromCart(id);
            return RedirectToAction(nameof(Details));
        }

        public IActionResult RemoveAll()
        {
            cartService.RemoveAll();
            return RedirectToAction(nameof(Details));
        }
    }
}
