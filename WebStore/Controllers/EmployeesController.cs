using Microsoft.AspNetCore.Mvc;

using System;

using WebStore.Infrastructure.Interfaces;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        #region Fields

        private readonly IEmployeesDataService dataService;
        #endregion


        #region CTORs

        public EmployeesController(IEmployeesDataService dataService)
        {
            this.dataService = dataService;
        }
        #endregion


        #region Main Presenters

        public IActionResult Index() => View(dataService.GetAll());

        public IActionResult Details(int id)
        {
            var employee = dataService.GetById(id);

            if (employee is null) return NotFound();
            return View(employee);
        }
        #endregion


        #region CRUD

        #region Редактирование

        public IActionResult Edit(int? Id)
        {
            if (Id is null) return View(new EmployeeViewModel());

            if (Id < 0) return BadRequest();

            var employee = dataService.GetById((int)Id);
            if (employee is null) return NotFound();

            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Surname = employee.Surname,
                Name = employee.FirstName,
                Patronymic = employee.Patronymic,
                Age = employee.Age
            });
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel Model)
        {
            _ = Model ?? throw new ArgumentNullException(nameof(Model));

            var employee = new Employee
            {
                Id = Model.Id,
                FirstName = Model.Name,
                Surname = Model.Surname,
                Patronymic = Model.Patronymic,
                Age = Model.Age
            };

            if (Model.Id == 0) dataService.Add(employee);
            else dataService.Edit(employee);

            dataService.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion


        #region Удаление

        public IActionResult Delete(int? id)
        {
            _ = id ?? throw new ArgumentNullException(nameof(id));
            if (id <= 0) return BadRequest();

            var employee = dataService.GetById((int)id);
            if (employee is null) return NotFound();

            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Surname = employee.Surname,
                Name = employee.FirstName,
                Patronymic = employee.Patronymic,
                Age = employee.Age
            });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            dataService.Delete(id);

            dataService.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion 
        #endregion
    }
}
