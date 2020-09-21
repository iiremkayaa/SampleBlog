using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Blog.Web.Models;

namespace Project.Blog.Web.Controllers
{
    public class LoginController : Controller
    {
       /* private readonly SignInManager<AppUser> _singInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _singInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }*/
        public IActionResult Index()
        {
            return View(/*new UserLoginModel()*/);
        }
        /*[HttpPost]
        public async Task<IActionResult> Index(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var identityResult=await _singInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, true);
                if (identityResult.IsLockedOut)
                {
                    ModelState.AddModelError("", "Account has been locked.");
                    View(model);
                }
                if (identityResult.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                ModelState.AddModelError("", "Username or password is incorrect.");
            }
            return View(model);
        }*/
    }
}
