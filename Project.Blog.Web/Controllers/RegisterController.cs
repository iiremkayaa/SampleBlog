using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Blog.Business.Interfaces;
using Project.Blog.Web.Context;
using Project.Blog.Web.Models;

namespace Project.Blog.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

        }
        /*private readonly IUserService _userService;
        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }*/
        /*public IActionResult Index()
        {
            return View();
        }*/
        public IActionResult Index()
        {
            return View(new UserRegisterModel());
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Email = model.Email,
                    Name = model.Name,
                    LastName = model.LastName,
                    UserName = model.Username,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                   return RedirectToAction("Index", "Login");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }
    }
}
