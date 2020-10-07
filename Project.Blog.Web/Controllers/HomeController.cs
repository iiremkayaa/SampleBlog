using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public HomeController(ICommentService commentService,ISharingService sharingService,UserManager<User> userManager,
            SignInManager<User> signInManager,IUserService userService, IMapper mapper)
        {
            _sharingService = sharingService;
            _userManager = userManager;
            _signInManager = signInManager;
            _commentService = commentService;
            _userService = userService;
            _mapper = mapper;

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
                SharingListModel model=_mapper.Map<SharingListModel>(item);

                var owner = await _userManager.FindByIdAsync(model.UserId.ToString());
                model.UserName = owner.UserName;

                models.Add(model);
                
            }
            return View(models);


        }
        public async Task<IActionResult> Detail(int id)
        {

            var currentUser = await GetCurrentUserAsync();
            var x = currentUser;
            Sharing sharing = await _sharingService.FindByIdAsync(id);
            var ne = sharing;
            if (sharing != null)
            {
                int? ownerId = sharing.UserId;
                SharingListModel model = _mapper.Map<SharingListModel>(sharing);
                var owner = await _userManager.FindByIdAsync(model.UserId.ToString());
                model.UserName = owner.UserName;
                
                List<Comment> comments = await _commentService.GetAllBySharingIdAsync(id);
                List<CommentListModel> commentModels = new List<CommentListModel>();
                foreach (var item in comments)
                {

                    if (item.UserId != null)
                    {
                        string userId = item.UserId.ToString();
                        var commentUser = await _userManager.FindByIdAsync(userId);

                        var result=await _commentService.isLiked(item.Id, currentUser.Id);
                        CommentListModel commentModel = _mapper.Map<CommentListModel>(item);
                        commentModel.CommentOwner = commentUser.UserName;
                        commentModel.CommentUsers = item.CommentUser;
                        commentModel.isLiked = result;
                    
                        commentModels.Add(commentModel);
                    }


                }

                ViewBag.Comments = commentModels;
                ViewBag.User = currentUser.UserName;
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
                UserId = currentUser.Id,
                SharingId = sharingId,
                /*User = await _userManager.FindByIdAsync(currentUser.Id.ToString()),
                Sharing=await _sharingService.FindByIdAsync(sharingId),*/

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
        [Authorize]
        public async Task<IActionResult> LikeComment(int id, int sharingId)
        {
            var currentUser = await GetCurrentUserAsync();
            int userId;
            if (currentUser != null)
            {
                userId = currentUser.Id;
                Comment comment = await _commentService.FindByIdAsync(id);                
                if(await _commentService.LikeComment(id, userId))
                {
                    comment.NumberOfLikes += 1;
                }
                else
                {
                    comment.NumberOfLikes--;
                }
                await _commentService.UpdateAsync(comment);
            }
            
            return RedirectToAction("Detail", new { id = sharingId });
        }
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        
        

    }
}
