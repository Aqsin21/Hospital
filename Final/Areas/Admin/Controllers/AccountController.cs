﻿using Final.Areas.Admin.ViewModels;
using Final.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> CreateAdmin()
        {
            AppUser admin = new()
            {
                FullName = "Abbaszade Aqsin",
                UserName = "Doctor"
            };

            await _userManager.CreateAsync(admin, "Admin123@");
            await _userManager.AddToRoleAsync(admin, "Doctor");
            return Ok("Admin yarandi!");
        }
        public async Task<IActionResult> CreateRoles()
        {
            IdentityRole role1 = new IdentityRole("Member");
            IdentityRole role2 = new IdentityRole("Doctor");
            IdentityRole role3 = new IdentityRole("SuperAdmin");

            await _roleManager.CreateAsync(role1);
            await _roleManager.CreateAsync(role2);
            await _roleManager.CreateAsync(role3);
            return Ok("Rollar yarandi!");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginVM adminLoginVM)
        {
            if (!ModelState.IsValid)
                return View();
            AppUser user = await _userManager.FindByNameAsync(adminLoginVM.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Username or password is not valid!");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, adminLoginVM.Password, adminLoginVM.IsPersistent, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or passwor dis not valid!");
                return View();
            }
            return RedirectToAction("Index", "Dashboard");
        }
    }
}