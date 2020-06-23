using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("/Errors/404")]
        public IActionResult Error404() => View();
        public IActionResult AccessDenied() => View();
    }
}
