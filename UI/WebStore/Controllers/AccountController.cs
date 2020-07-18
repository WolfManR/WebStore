using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Linq;
using System.Threading.Tasks;

using WebStore.Domain.Entities.Identity;
using WebStore.Domain.ViewModels.Identity;

namespace WebStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }

        public async Task<IActionResult> IsNameFree(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            logger.LogInformation("User {0} {1} exists", userName, user is null ? "не" : null);
            return Json(user is null ? "true" : "A user with the same name already exists");
        }

        #region Register

        public IActionResult Register() => View(new RegisterUserViewModel());

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new User { UserName = model.UserName };

            using (logger.BeginScope("New User Registration {0}", user.UserName))
            {
                logger.LogInformation("The process of registering a new user {0}", user.UserName);

                var registrationResult = await userManager.CreateAsync(user, model.Password);
                if (registrationResult.Succeeded)
                {
                    logger.LogInformation("User {0} successfully registered", user.UserName);

                    var addUserRoleResult = await userManager.AddToRoleAsync(user, Role.User);
                    //if (addUserRoleResult.Succeeded) logger.LogInformation("Role {0} successfully added to user", Role.User);
                    //else
                    //{
                    //    logger.LogError("Error adding user role {0}: {1}",Role.User, string.Join(",", addUserRoleResult.Errors.Select(error => error.Description)));

                    //    throw new ApplicationException("Error assigning a new user to the User role");
                    //}


                    await signInManager.SignInAsync(user, false);

                    logger.LogInformation("User {0} successfully logged in", user.UserName);

                    return RedirectToAction("Home", "Shop");
                }

                logger.LogError("Error adding new user of role {0}: {1}",user.UserName, string.Join(",", registrationResult.Errors.Select(error => error.Description)));

                foreach (var error in registrationResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
        #endregion


        #region Login

        public IActionResult Login(string returnUrl) => View(new LoginViewModel { ReturnUrl = returnUrl });

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var loginResult = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            if (loginResult.Succeeded)
            {
                logger.LogInformation("User {0} successfully logged in", model.UserName);

                if (Url.IsLocalUrl(model.ReturnUrl))
                {
                    logger.LogDebug("Redirecting to {0}", model.ReturnUrl);

                    return Redirect(model.ReturnUrl);
                }

                logger.LogDebug("Redirecting to the main page");
                return RedirectToAction("Home", "Shop");
            }

            logger.LogWarning("User {0} made an incorrect login attempt");

            ModelState.AddModelError(string.Empty, "Wrong username or password");

            return View(model);
        }
        #endregion


        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var userName = User.Identity.Name;
            await signInManager.SignOutAsync();

            logger.LogInformation("User {0} has logged out", userName);

            return RedirectToAction("Home", "Shop");
        }
    }
}
