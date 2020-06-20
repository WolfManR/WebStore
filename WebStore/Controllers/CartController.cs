using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels.Products.Orders;

namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartDataService cartService;

        public CartController(ICartDataService CartService) => cartService = CartService;

        public IActionResult Details() => View(new CartOrderViewModel {
            Cart=cartService.TransformFromCart(),
            Order=new OrderViewModel()
        });


        #region Cart CRUD

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
        #endregion


        #region CheckOut

        [HttpPost]
        public async Task<IActionResult> CheckOut(OrderViewModel model, [FromServices] IOrderDataService orderDataService)
        {
            if (!ModelState.IsValid)
                return View(nameof(Details), new CartOrderViewModel
                {
                    Cart = cartService.TransformFromCart(),
                    Order = model
                });

            var order = await orderDataService.CreateOrder(User.Identity.Name, cartService.TransformFromCart(), model);

            cartService.RemoveAll();

            return RedirectToAction(nameof(OrderConfirmed), new { id = order.Id });
        }

        public IActionResult OrderConfirmed(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }
        #endregion
    }
}
