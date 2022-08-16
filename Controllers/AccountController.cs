using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Eshopper.Models.ViewModels;
namespace Eshopper.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userMgr,
        SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }
        public ViewResult Login()
        {
            return View(new LoginModel
            {
            });
        }

        public ViewResult Register()
        {
            return View(new RegisterModel
            {
            });
        }

        public ViewResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user =
                await userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                    loginModel.Password, false, false)).Succeeded)
                    {
                        if (await userManager.IsInRoleAsync(user, "Admin")) {
                            return Redirect("/admin");
                        }

                        return Redirect("/");
                    }
                }
                ModelState.AddModelError("", "Invalid name or password");
            }
            return View(loginModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user =
                    new IdentityUser { UserName = registerModel.UserName, Email = registerModel.Email };
                await userManager.CreateAsync(user, registerModel.Password);
                IdentityResult result = await userManager.AddToRoleAsync(user, "User");
                if (result.Succeeded)
                {
                    return Redirect("/Account/Login");
                }
                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View(registerModel);
        }

        [Authorize]
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}