using Microsoft.AspNetCore.Mvc;
using WebStore.Interfaces.TestApi;

namespace WebStore.Controllers
{
    public class WebApiTestController : Controller
    {
        private readonly IValueService valueService;

        public WebApiTestController(IValueService valueService) => this.valueService = valueService;

        public IActionResult Index()
        {
            var values = valueService.Get();
            return View(values);
        }
    }
}
