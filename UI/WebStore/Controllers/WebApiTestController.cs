using System;
using System.Net;
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

        public IActionResult Edit(int? id)
        {
            _ = id ?? throw new ArgumentNullException("There no entry");
            if (id < 0) return BadRequest();
            return View(((int)id,valueService.Get((int) id)));
        }

        [HttpPost]
        public IActionResult Edit(int Item1, string Item2)
        {
            return valueService.Update(Item1, Item2) switch
            {
                HttpStatusCode.OK => RedirectToAction(nameof(Index)),
                _ => BadRequest()
            };
        }

        public IActionResult Delete(int? id)
        {
            _ = id ?? throw new ArgumentNullException("There no entry");
            if (id < 0) return BadRequest();

            var entry=valueService.Get((int) id);
            if (entry == null) return NotFound();

            return View((int) id);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            return valueService.Delete(id) switch
            {
                HttpStatusCode.OK => RedirectToAction(nameof(Index)),
                _ => BadRequest()
            };
        }
    }
}
