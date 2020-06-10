using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult Error404() => View();

        public IActionResult AccessDenied() => View();
    }
}
