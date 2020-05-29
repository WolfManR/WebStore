using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult BlogList() => View();
        public IActionResult BlogSingle() => View();
    }
}
