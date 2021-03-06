﻿using Microsoft.AspNetCore.Mvc;

using System.Linq;
using System.Threading.Tasks;

using WebStore.Domain.DTO.Order;
using WebStore.Domain.ViewModels.Products.Orders;
using WebStore.Interfaces.Services;

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

            var orderModel = new CreateOrderModel
            {
                Order = model,
                Items = cartService.TransformFromCart().Items.Select(item => new OrderItemDTO
                {
                    Id = item.product.Id,
                    Price = item.product.Price,
                    Quantity = item.quantity
                }).ToList()
            };

            var order = await orderDataService.CreateOrder(User.Identity.Name,orderModel);

            cartService.RemoveAll();

            return RedirectToAction(nameof(OrderConfirmed), new { id = order.Id });
        }

        public IActionResult OrderConfirmed(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }
        #endregion


        #region WebApi

        public IActionResult GetCartView() => ViewComponent("Cart");

        public IActionResult AddToCartAPI(int id)
        {
            cartService.AddToCart(id);
            return Json(new { id, message = $"Product id:{id} was added in cart" });
        }

        public IActionResult DecrementFromCartAPI(int id)
        {
            cartService.DecrementFromCart(id);
            return Ok();
        }

        public IActionResult RemoveFromCartAPI(int id)
        {
            cartService.RemoveFromCart(id);
            return Ok();
        }

        public IActionResult RemoveAllAPI()
        {
            cartService.RemoveAll();
            return Ok();
        }

        #endregion
    }
}
