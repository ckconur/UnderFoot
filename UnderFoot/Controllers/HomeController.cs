using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderFoot.DataAccess;
using UnderFoot.Models;

namespace UnderFoot.Controllers
{
    public class HomeController : Controller
    {
        public UserManager<AppUser> userManager { get; }
        public SignInManager<AppUser> signInManager { get; }
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index(string ReturnUrl)
        {
            TempData["ReturnUrl"] = ReturnUrl;

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "User");
            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                AppUser newUser = new AppUser()
                {
                    UserName = userVM.UserName,
                    Email = userVM.Email
                };

                IdentityResult result = await userManager.CreateAsync(newUser, userVM.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(userVM);
        }

        public PartialViewResult LogIn()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel LoginVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(LoginVM.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, LoginVM.Password, LoginVM.RememberMe, false);

                    if (result.Succeeded)
                    {
                        if (TempData["ReturnUrl"] != null)
                        {
                            return Redirect(TempData["ReturnUrl"].ToString());
                        }

                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(LoginVM.Email), "Geçersiz email veya şifre girildi.");
                    }
                }                
            }

            return View();
        }
    }

    // TODO: Orders oluşturulacak burada Order-User(one-many) arasında bir ilişki kurulacak bir kullanıcının birden fazla siparişi olabilir, OrderDetails tablosu yapılacak burada Order-Product(one-many) bir siparişte birden fazla ürün olabilir, Carts tablosu olacak Cart-Products (one-many) bir sepette birden fazla ürün bulunabilir.
}
