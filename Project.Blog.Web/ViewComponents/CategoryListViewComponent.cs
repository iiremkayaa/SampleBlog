using Microsoft.AspNetCore.Mvc;
using Project.Blog.Business.Interfaces;
using Project.Blog.Entities.Concrete;
using Project.Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Blog.Web.ViewComponents
{
    public class CategoryListViewComponent :ViewComponent
    {
        private readonly ICategoryService _categoryService;
        //private readonly IMapper _mapper;
        public CategoryListViewComponent(ICategoryService categoryService/*,IMapper mapper*/)
        {
            _categoryService = categoryService;
            //_mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> categories = await _categoryService.GetAllAsync();
            List<CategoryListModel> models = new List<CategoryListModel>();
            foreach (var item in categories)
            {
                CategoryListModel model = new CategoryListModel
                {
                    Id = item.Id,
                    Name = item.Name,
                };
                models.Add(model);
            }


            return View(models);
        }

    }
}
