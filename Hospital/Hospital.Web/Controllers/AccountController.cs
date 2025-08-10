using Hospital.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Controllers
{
    public class AccountController : Controller
    {
        
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction("Login" , "Account");
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
