using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Project.Blog.Business.Interfaces;
using Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Context;
using Project.Blog.Entities.Concrete;
using Project.Blog.Web.Models;

namespace Project.Blog.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly BlogContext _blogContext ;

        public AccountController(IUserService userService, BlogContext blogContext)
        {
            _userService = userService;
            _blogContext = blogContext;
        }
        public AccountController(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        [Route("/Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel loginModel)
        {
            User user = await _userService.FindByUsernameAsync(loginModel.Username);
            if (user != null)
            {

                UserListModel model = new UserListModel
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                };
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginModel.Username)
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");
            }
           
        
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }

        
        [Route("/Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        private static string ComputeSha256Hash(string rawData)
        {

            using (SHA256 sha256Hash = SHA256.Create())
            {

                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string HashCode = ComputeSha256Hash(registerModel.Password).Substring(0, 20);
                    registerModel.Password = HashCode;
                    var user = new User
                    {
                        Username = registerModel.Username,
                        Name = registerModel.Name,
                        LastName = registerModel.LastName,
                        Email = registerModel.Email,
                        Password = registerModel.Password

                    };
                    _blogContext.Users.Add(user);
                    await _blogContext.SaveChangesAsync();
                    var claims = new List<Claim>{
                        new Claim(ClaimTypes.Name, user.Username)
                    };
                    var userIdentity = new ClaimsIdentity(claims, "login");

                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception e)
                {
                    var error = e.Message;
                    ViewBag.Message = "Please fill all fields";
                    return View();

                }
            }
            return View();
        }
    }

}
