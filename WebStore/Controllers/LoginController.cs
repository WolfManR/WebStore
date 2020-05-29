using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginForm()
        {
            return View();
        }
    }
}
