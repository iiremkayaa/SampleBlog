using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Blog.Business.Interfaces;
using Project.Blog.Entities.Concrete;
using Project.Blog.Web.Models;

namespace Project.Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISharingService _sharingService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public HomeController(ISharingService sharingService,UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _sharingService = sharingService;
            _userManager = userManager;
            _signInManager = signInManager;

        }
        [Authorize]
        public async Task<IActionResult> IndexAsync()
        {
            List<Sharing> sharings = await _sharingService.GetAllAsync();
            List<SharingListModel> models = new List<SharingListModel>();
            foreach (var item in sharings)
            {
                SharingListModel model = new SharingListModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description=item.Description,
                    SharingDate=item.SharingDate
                };
                models.Add(model);
            }
            return View(models);
        }
        [Authorize]
        public async Task<IActionResult> Detail(int id)
        {

            Sharing sharing = await _sharingService.FindByIdAsync(id);
            SharingListModel model = new SharingListModel
            {
                    Id = sharing.Id,
                    Title = sharing.Title,
                    Description = sharing.Description,
                    SharingDate = sharing.SharingDate,
            };
            return View(model);
        }
        [Route("/login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
           
            var result = await _signInManager.PasswordSignInAsync(model.Username,
                           model.Password, model.RememberMe, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
       

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Email = model.Email,
                    Name = model.Name,
                    LastName = model.LastName,
                    UserName = model.Username,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var resultSıgnIn = await _signInManager.PasswordSignInAsync(model.Username,model.Password,false,lockoutOnFailure: true);
                    if (resultSıgnIn.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Login", "Home");
                    }
                    

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
