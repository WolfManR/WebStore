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

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            employees.Add(employee);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));
            var employee = employees.First(x => Equals(x.Id, id));
            return employee != null ? (IActionResult)View(employee) : NotFound();
        }
        [HttpPost]
        public IActionResult Edit(int Id, Employee employee)
        {
            if (Id == employee.Id) return null;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete() => View();

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            employees.Remove(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}
