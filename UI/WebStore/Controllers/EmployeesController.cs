﻿using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Linq;

using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.ViewModels;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        #region Fields

        private readonly IRepo<Employee> dataService;
        private readonly IMapper mapper;
        #endregion


        #region CTORs

        public EmployeesController(IRepo<Employee> dataService, IMapper mapper)
        {
            this.dataService = dataService;
            this.mapper = mapper;
        }
        #endregion


        #region Main Presenters

        [AllowAnonymous]
        public IActionResult Index() => View(dataService.GetAll().Select(employee => new EmployeeViewModel
        {
            Id = employee.Id,
            Surname = employee.Surname,
            Firstname = employee.Firstname,
            Age = employee.Age
        }));

        [Authorize(Roles = Role.User)]
        public IActionResult Details(int id)
        {
            var employee = dataService.GetById(id);

            if (employee is null) return NotFound();
            return View(mapper.Map<EmployeeViewModel>(employee));
        }
        #endregion


        #region CRUD

        #region Редактирование

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Edit(int? Id)
        {
            ViewBag.Avatars = new SelectList(new[] { "man-one.jpg", "man-two.jpg", "man-three.jpg", "man-four.jpg" });
            if (Id is null) return View(new EmployeeViewModel());

            if (Id < 0) return BadRequest();

            var employee = dataService.GetById((int)Id);
            if (employee is null) return NotFound();


            return View(mapper.Map<EmployeeViewModel>(employee));
        }
        
        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult Edit(EmployeeViewModel model)
        {
            _ = model ?? throw new ArgumentNullException(nameof(model));

            if (!ModelState.IsValid) return View(model);

            var employee = mapper.Map<Employee>(model);

            if (model.Id == 0) dataService.Add(employee);
            else dataService.Edit(employee);

            try
            {
                dataService.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }

        #endregion


        #region Удаление

        [Authorize(Roles = Role.Administrator)]
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
                Firstname = employee.Firstname,
                Age = employee.Age
            });
        }
        
        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult Delete(int id)
        {
            dataService.Delete(id);

            try
            {
                dataService.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }

        #endregion 
        #endregion
    }
}
