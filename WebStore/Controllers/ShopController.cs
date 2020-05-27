using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Products() => View();
        public IActionResult ProductDetails() => View();
        public IActionResult Checkout() => View();
        public IActionResult Cart() => View();
    }
}
