using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;

using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        private static readonly List<Employee> employees = TestData.Employees;

        public IActionResult Index()
        {
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee is null) return NotFound();
            return View(employee);
        }
    }
}
