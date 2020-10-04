using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Blog.Business.Interfaces;
using Project.Blog.Entities.Concrete;
using Project.Blog.Web.Models;

namespace Project.Blog.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public ProfileController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> IndexAsync()
        {
            User user = await GetCurrentUserAsync();
            UserListModel model;
            if (user != null)
            {
                 model = new UserListModel
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Gender = user.Gender,
                    Name = user.Name,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Sharings = user.Sharings,
                    Comments = user.Comments,
                    Email=user.Email,
                };
            }
            else
            {
                model = new UserListModel();
            }
            
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(UserListModel model)
        {
            var id = model.Id.ToString();
            if (id != null)
            {
                User user = await _userManager.FindByIdAsync(id);
                user.Name = model.Name;
                user.UserName = model.Username;
                user.LastName = model.LastName;
                user.Gender = model.Gender;
                user.PhoneNumber = model.PhoneNumber;
                
                var result=await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    ViewBag.Result = "All changes saved.";
                }
                else
                {
                    ViewBag.Result = "Username is already in use.";
                }
            }
            return View(model);

        }
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
