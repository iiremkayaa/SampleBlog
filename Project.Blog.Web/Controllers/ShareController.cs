﻿using System;
using System.Collections.Generic;
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
    public class ShareController : Controller
    {
        private readonly ISharingService _sharingService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public ShareController(ISharingService sharingService, UserManager<User> userManager,
            SignInManager<User> signInManager, IMapper mapper,ICategoryService categoryService)
        {
            _sharingService = sharingService;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _categoryService = categoryService;

        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<Category> categories=await _categoryService.GetAllAsync();
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(SharingPostModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await GetCurrentUserAsync();
                Sharing sharing=  _mapper.Map<Sharing>(model);
                if (currentUser != null)
                {
                    sharing.UserId = currentUser.Id;
                }
                sharing.SharingDate = DateTime.Now;
                
                await _sharingService.AddAsync(sharing);
                return RedirectToAction("Index", "Home");
               
                
            }
            return View();

        }
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    }
}
