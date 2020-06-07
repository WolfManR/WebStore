using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Linq;

using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class AccountsController : Controller
    {
        #region Fields

        private readonly IRepo<Account> dataService;
        #endregion


        #region CTORs

        public AccountsController(IRepo<Account> dataService) => this.dataService = dataService;
        #endregion


        #region Main Presenters

        public IActionResult Index() => View(dataService.GetAll().Select(account=>new AccountViewModel{
            Id = account.Id,
            Surname = account.Surname,
            Firstname = account.Firstname,
            Age = account.Age
        }));

        public IActionResult Details(int id)
        {
            var account = dataService.GetById(id);

            if (account is null) return NotFound();
            return View(new AccountViewModel {
                Id = account.Id,
                Firstname = account.Firstname,
                Surname = account.Surname,
                AvatarUrl = account.AvatarUrl,
                Age = account.Age,
                Sex = account.Sex,
                Birthday = account.BirthdayDate
            });
        }
        #endregion


        #region CRUD

        #region Редактирование

        public IActionResult Edit(int? Id)
        {
            ViewBag.Avatars = new SelectList(new[] { "man-one.jpg", "man-two.jpg", "man-three.jpg", "man-four.jpg" });
            if (Id is null) return View(new AccountViewModel());

            if (Id < 0) return BadRequest();

            var account = dataService.GetById((int)Id);
            if (account is null) return NotFound();


            return View(new AccountViewModel
            {
                Id = account.Id,
                Firstname = account.Firstname,
                Surname = account.Surname,
                AvatarUrl=account.AvatarUrl,
                Age = account.Age,
                Sex=account.Sex,
                Birthday=account.BirthdayDate
            });
        }

        [HttpPost]
        public IActionResult Edit(AccountViewModel model)
        {
            _ = model ?? throw new ArgumentNullException(nameof(model));

            if (!ModelState.IsValid) return View(model);

            var account = new Account
            {
                Id = model.Id,
                Firstname = model.Firstname,
                Surname = model.Surname,
                AvatarUrl=model.AvatarUrl,
                Age = model.Age,
                Sex=model.Sex,
                BirthdayDate=model.Birthday
            };

            if (model.Id == 0) dataService.Add(account);
            else dataService.Edit(account);

            return RedirectToAction("Index");
        }

        #endregion


        #region Удаление

        public IActionResult Delete(int? id)
        {
            _ = id ?? throw new ArgumentNullException(nameof(id));
            if (id <= 0) return BadRequest();

            var account = dataService.GetById((int)id);
            if (account is null) return NotFound();

            return View(new AccountViewModel
            {
                Id = account.Id,
                Surname = account.Surname,
                Firstname = account.Firstname,
                Age = account.Age
            });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            dataService.Delete(id);

            return RedirectToAction("Index");
        }

        #endregion 
        #endregion
    }
}
