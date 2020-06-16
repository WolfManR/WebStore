using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    [Route("Error")]
    public class ErrorsController : Controller
    {
        [Route("404")]
        public IActionResult Error404() => View();
        [Route("403")]
        [Route("401")]
        public IActionResult AccessDenied() => View();
    }
}
