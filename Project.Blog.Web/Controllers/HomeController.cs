using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
            public HomeController(ICommentService commentService,ISharingService sharingService,UserManager<User> userManager,
            SignInManager<User> signInManager,IUserService userService)
        {
            _sharingService = sharingService;
            _userManager = userManager;
            _signInManager = signInManager;
            _commentService = commentService;
            _userService = userService;

        }
        public async Task<IActionResult> IndexAsync(int? categoryId,string key)
        {
            List<SharingListModel> models = new List<SharingListModel>();
            List<Sharing> sharings = new List<Sharing>();

            if (categoryId == null  && string.IsNullOrWhiteSpace(key))
            {
                sharings = await _sharingService.GetAllSortedByDateAsync();
                
            }
            else if (!string.IsNullOrWhiteSpace(key))
            {
                sharings = await _sharingService.SearchSharingAsync(key);
            }
            else
            {
                sharings = await _sharingService.GetAllByCategoryIdAsync((int)categoryId);

            }

            
            foreach (var item in sharings)
            {
                string userId = item.UserId.ToString();
                var user = await _userManager.FindByIdAsync(userId);
                SharingListModel model = new SharingListModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    SharingDate = item.SharingDate,
                    UserName=user.UserName,
                    
                };
                models.Add(model);

            }
            return View(models);


        }
        public async Task<IActionResult> Detail(int id)
        {

            Sharing sharing = await _sharingService.FindByIdAsync(id);
            if (sharing != null)
            {
                int? ownerId = sharing.UserId;
                User user = new User();
                user = await _userManager.FindByIdAsync(ownerId.ToString());
                SharingListModel model = new SharingListModel
                {
                    Id = sharing.Id,
                    Title = sharing.Title,
                    Description = sharing.Description,
                    SharingDate = sharing.SharingDate,
                    UserName = user.UserName,
                };
                List<Comment> comments = await _commentService.GetAllBySharingIdAsync(id);
                List<CommentListModel> commentModels = new List<CommentListModel>();
                foreach (var item in comments)
                {

                    if (item.CommentOwnerId != null)
                    {
                        string userId = item.CommentOwnerId.ToString();
                        var commentUser = await _userManager.FindByIdAsync(userId);
                        CommentListModel commentModel = new CommentListModel
                        {
                            Id = item.Id,
                            Description = item.Description,
                            CommentDate = item.CommentDate,
                            NumberOfLikes = item.NumberOfLikes,
                            LastModificationDate = item.LastModificationDate,
                            UserName = commentUser.UserName

                        };
                        commentModels.Add(commentModel);
                    }


                }

                ViewBag.Comments = commentModels;
                return View(model);
            }
            return BadRequest("");
            
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Detail(string description, int sharingId)
        {
            var currentUser = await GetCurrentUserAsync();
            Comment comment = new Comment
            {
                Description = description,
                CommentDate = DateTime.Now,
                NumberOfLikes = 0,
                LastModificationDate = DateTime.Now,
                CommentOwnerId = currentUser?.Id,
                SharingId = sharingId
            };
            await _commentService.AddAsync(comment);
            return RedirectToAction("Detail", sharingId);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.Username,
                               model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Wrong username or password.";
                }
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
                var emailIsExist=await _userManager.FindByEmailAsync(model.Email);
                var userNameIsExist = await _userManager.Users.Where(u=>u.UserName==model.Username).ToListAsync();
                //await _userService.GetByUserNameAsync(model.Username);
                if (emailIsExist!=null)
                {
                    ViewBag.EmailError = "Email is already taken.";
                }
                else if (userNameIsExist.Count > 0)
                {
                    ViewBag.UserNameError = "Username is already taken.";
                }
                else
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
                        var resultSıgnIn = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: true);
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
                

            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> DeleteComment(int id,int sharingId)
        {
            var num = sharingId;
            await _commentService.RemoveAsync(id);
            return RedirectToAction("Detail", new { id = sharingId } );
        }
        public async Task<IActionResult> LikeComment(int id, int sharingId)
        {

            Comment comment =await _commentService.FindByIdAsync(id);
            comment.NumberOfLikes +=1;
            await _commentService.UpdateAsync(comment);
            return RedirectToAction("Detail", new { id = sharingId });
        }
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        
        

    }
}
