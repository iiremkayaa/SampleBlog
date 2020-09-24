using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Blog.Business.Interfaces;
using Project.Blog.Entities.Concrete;
using Project.Blog.Web.Models;
namespace Project.Blog.Web.Controllers
{
    public class ShareController : Controller
    {
        private readonly ISharingService _sharingService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public ShareController(ISharingService sharingService, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _sharingService = sharingService;
            _userManager = userManager;
            _signInManager = signInManager;

        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(SharingPostModel model)
        {
            var currentUser = await GetCurrentUserAsync();
            Sharing sharing = new Sharing
            {
                Title=model.Title,
                Description=model.Description,
                CategoryId=model.CategoryId,
                SharingDate=DateTime.Now,
                UserId=currentUser?.Id
            };
            await _sharingService.AddAsync(sharing);

            return View();
        }
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    }
}
