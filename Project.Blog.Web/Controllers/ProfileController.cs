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
        public async Task<IActionResult> IndexAsync(int? id)
        {
            var ne = id;
            List<Sharing> sharings;
            if (id == null)
            {
                User currentUser = await GetCurrentUserAsync();
                sharings = await _sharingService.GetAllByUserIdAsync(currentUser.Id);
                ViewBag.Current = true;
            }
            else
            {
                sharings = await _sharingService.GetAllByUserIdAsync((int)id);
                ViewBag.Current = false;
            }
            List<SharingListModel> models = new List<SharingListModel>();

            foreach (var item in sharings)
            {
                string userId = item.UserId.ToString();
                var user = await _userManager.FindByIdAsync(userId);
             
                List<Comment> comments= await _commentService.GetAllBySharingIdAsync(item.Id);
                          
                SharingListModel model = _mapper.Map<SharingListModel>(item);
                model.UserName = user.UserName;
                model.NumberOfComments = comments.Count;  
                
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
                SharingListModel model = _mapper.Map<SharingListModel>(sharing);
                model.UserName = user.UserName;
                
                List<Comment> comments = await _commentService.GetAllBySharingIdAsync(id);
                List<CommentListModel> commentModels = new List<CommentListModel>();
                foreach (var item in comments)
                {

                    if (item.UserId != null)
                    {
                        string userId = item.UserId.ToString();
                        var commentUser = await _userManager.FindByIdAsync(userId);

                        var result = await _commentService.isLiked(item.Id, currentUser.Id);
                        CommentListModel commentModel = _mapper.Map<CommentListModel>(item);
                        commentModel.CommentOwner = commentUser.UserName;
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
                UserId = currentUser?.Id,
                SharingId = sharingId,
                
            };
            await _commentService.AddAsync(comment);
            return RedirectToAction("Detail","Profile", sharingId);
        }
        public async Task<IActionResult> DeleteComment(int id, int sharingId)
        {
            var num = sharingId;
            await _commentService.RemoveAsync(id);
            return RedirectToAction("Detail", new { id = sharingId });
        }
        public async Task<IActionResult> DeleteSharing(int id,int user)
        {
            await _sharingService.RemoveAsync(id);
            return RedirectToAction("Index", "Profile");
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
                if (await _commentService.LikeComment(id, userId))
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
