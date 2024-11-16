using Final.Core.Models;
using Final.Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;

namespace Final.Controllers

    
{
    public class AccountController : Controller
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Register model)
        {

            if (ModelState.IsValid)
            {

                if (_context.Users.Any(u => u.UserName == model.UserName))
                {
                    ModelState.AddModelError("Username", "Bu kullanıcı adı zaten alınmış.");
                    return View(model);
                }


                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);




                _context.Users.Add(model);
                _context.SaveChanges();


                return RedirectToAction("Index", "Home");
            }


            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
