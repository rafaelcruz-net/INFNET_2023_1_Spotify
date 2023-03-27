using Microsoft.AspNetCore.Mvc;
using MVC.Models.Account;
using MVC.Repository;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {

        private IAccountManager accountManager;

        public AccountController(IAccountManager accountManager)
        {
            this.accountManager = accountManager;
        }

        public IActionResult Login([FromQuery] string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm] UserAccount userAccount, [FromQuery] string? returnUrl)
        {
            if (ModelState.IsValid == false) 
            { 
                return View(userAccount);
            }

            var result = this.accountManager.Login(userAccount.Email, userAccount.Password).Result;

            if (result.Succeeded)
            {
                if (string.IsNullOrEmpty(returnUrl) == false)
                    return Redirect(returnUrl);

                return Redirect("/Home");
            }

            ViewBag.LoginError = "Email/Password inválidos";

            return View(userAccount);
        }

        public IActionResult Logout()
        {
            this.accountManager.Logout();
            return RedirectToAction("Login");
        }
    }
}
