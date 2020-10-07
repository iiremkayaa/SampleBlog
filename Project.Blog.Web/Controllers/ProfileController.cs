using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ISharingService _sharingService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public ProfileController(IMapper mapper,ICommentService commentService, SignInManager<User> signInManager, UserManager<User> userManager,ISharingService sharingService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _sharingService = sharingService;
            _commentService = commentService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexAsync()
        {
            User currentUser= await GetCurrentUserAsync();
            List<Sharing> sharings = await _sharingService.GetAllByUserIdAsync(currentUser.Id);
            
            List<SharingListModel> models = new List<SharingListModel>();

            foreach (var item in sharings)
            {
                //SharingListModel sharingListModel=_mapper.Map<SharingListModel>(item);
                string userId = item.UserId.ToString();
                var user = await _userManager.FindByIdAsync(userId);
                int numberOfComment = 0;
                if (item.Comments != null)
                {
                    numberOfComment = item.Comments.Count;
                }                
                SharingListModel model = _mapper.Map<SharingListModel>(item);
                model.UserName = user.UserName;
                model.numberOfLikes = 5;
                model.numberOfComments = 10;
                
                models.Add(model);

            }
            return View(models);
        }
        
        public async Task<IActionResult> SettingAsync()
        {
            User user = await GetCurrentUserAsync();
            UserListModel model;
            if (user != null)
            {
                model=_mapper.Map<UserListModel>(user);
                /*model = new UserListModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Gender = user.Gender,
                    Name = user.Name,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Sharings = user.Sharings,
                    Comments = user.Comments,
                    Email = user.Email,
                };*/
            }
            else
            {
                model = new UserListModel();
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SettingAsync(UserListModel model)
        {
            var id = model.Id.ToString();
            if (id != null)
            {
                User user=_mapper.Map<User>(await _userManager.FindByIdAsync(id));
                user.Name = model.Name;
                user.UserName = model.UserName;
                user.LastName = model.LastName;
                user.Gender = model.Gender;
                user.PhoneNumber = model.PhoneNumber;

                var result = await _userManager.UpdateAsync(user);
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
        public async Task<IActionResult> Detail(int id)
        {
            var currentUser = await GetCurrentUserAsync();

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
                    //UserName = user.UserName,
                };
                List<Comment> comments = await _commentService.GetAllBySharingIdAsync(id);
                List<CommentListModel> commentModels = new List<CommentListModel>();
                foreach (var item in comments)
                {

                    if (item.UserId != null)
                    {
                        string userId = item.UserId.ToString();
                        var commentUser = await _userManager.FindByIdAsync(userId);

                        var result = await _commentService.isLiked(item.Id, currentUser.Id);
                        CommentListModel commentModel = new CommentListModel
                        {
                            Id = item.Id,
                            Description = item.Description,
                            CommentDate = item.CommentDate,
                            NumberOfLikes = item.NumberOfLikes,
                            LastModificationDate = item.LastModificationDate,
                            //UserName = commentUser.UserName,
                            CommentUsers = item.CommentUser,
                            isLiked = result,

                        };
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
                UserId = currentUser?.Id,
                SharingId = sharingId,
                
            };
            await _commentService.AddAsync(comment);
            return RedirectToAction("Detail", sharingId);
        }

        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
