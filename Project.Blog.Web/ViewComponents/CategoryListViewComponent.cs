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
        private readonly ISharingService _sharingService;
        public CategoryListViewComponent(ICategoryService categoryService,ISharingService sharingService)
        {
            _categoryService = categoryService;
            _sharingService = sharingService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> categories = await _categoryService.GetAllAsync();
            List<CategoryListModel> models = new List<CategoryListModel>();
            foreach (var item in categories)
            {
                List<Sharing> sharings = await _sharingService.GetAllByCategoryIdAsync(item.Id);
                CategoryListModel model = new CategoryListModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Number = sharings.Count
                };
                models.Add(model);
            }


            return View(models);
        }

    }
}
