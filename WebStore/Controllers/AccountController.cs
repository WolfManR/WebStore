using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using WebStore.ViewModels.Identity;

namespace WebStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Domain.Entities.Identity.User> userManager;
        private readonly SignInManager<Domain.Entities.Identity.User> signInManager;

        public AccountController(UserManager<Domain.Entities.Identity.User> userManager, SignInManager<Domain.Entities.Identity.User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #region Register

        public IActionResult Register() => View(new RegisterUserViewModel());

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new Domain.Entities.Identity.User { UserName = model.UserName };

            var registration_result = await userManager.CreateAsync(user, model.Password);
            if (registration_result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                return RedirectToAction("Home", "Shop");
            }

            foreach (var error in registration_result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
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

            var login_result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            if (login_result.Succeeded)
            {
                if (Url.IsLocalUrl(model.ReturnUrl)) return Redirect(model.ReturnUrl);
                return RedirectToAction("Home", "Shop");
            }

            ModelState.AddModelError(string.Empty, "Wrong username or password");

            return View(model);
        }
        #endregion
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Home", "Shop");
        }
    }
}
