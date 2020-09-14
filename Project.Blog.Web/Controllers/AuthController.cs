using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Blog.Business.Interfaces;
using Project.Blog.Entities.Concrete;
using Project.Blog.Web.Models;

namespace Project.Blog.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;

        }
        public async Task<IActionResult> IndexAsync(string username)
        {
            User user = await _userService.FindByUsernameAsync(username);
            
            UserListModel model = new UserListModel
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,

                };
            return View(model);
            
           
        }



    }
    /*[HttpPost("[action]")]
    public  Task<IActionResult> SignIn(UserLoginModel userLoginModel)
    {
        var appUser = await _userService.FindByUserName(userLoginModel.UserName);
        if (appUser == null)
        {
            return BadRequest("Username or password is incorrect.");
        }
        else
        {
            if (await _appUserService.CheckPassword(appUserLoginDto))
            {
                var roles = await _appUserService.GetRolesByUserName(appUserLoginDto.UserName);
                var token = _jwtService.GenerateJwtToken(appUser, roles);
                JwtAccessToken jwtAccessToken = new JwtAccessToken();
                jwtAccessToken.Token = token;
                return Created("", jwtAccessToken);
            }
            else
            {
                return BadRequest("Username or password is incorrect.");
            }
        }

    }*/


}
