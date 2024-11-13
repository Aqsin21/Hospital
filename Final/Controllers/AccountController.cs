using Microsoft.AspNetCore.Mvc;

namespace Final.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }
    }
}
