using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Blog.Business.Interfaces;
using Project.Blog.Dto.DTOs.CategoryDtos;
using Project.Blog.Entities.Concrete;
using Project.Blog.Web.Models;

namespace Project.Blog.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        //private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService/*,IMapper mapper*/)
        {
            _categoryService = categoryService;
            //_mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        

        /*public async Task<IActionResult> All()
        {
            List<Category> categories= await _categoryService.GetAllAsync();
            List<CategoryListModel> models = new List<CategoryListModel>();
            foreach(var item in categories)
            {
                CategoryListModel model = new CategoryListModel
                {
                    Id = item.Id,
                    Name = item.Name,
                };
                models.Add(model);
            }
           

            return View(models);
        }*/
        public async Task<IActionResult> Details(int id)
        {
            Category category=await _categoryService.FindByIdAsync(id);
            return View(category);

        }
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
