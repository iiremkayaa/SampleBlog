using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Blog.Business.Interfaces;
using Project.Blog.Entities.Concrete;
using Project.Blog.Web.Models;

namespace Project.Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISharingService _sharingService;
        public HomeController(ISharingService sharingService)
        {
            _sharingService = sharingService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            List<Sharing> sharings = await _sharingService.GetAllAsync();
            List<SharingListModel> models = new List<SharingListModel>();
            foreach (var item in sharings)
            {
                SharingListModel model = new SharingListModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description=item.Description,
                    SharingDate=item.SharingDate
                };
                models.Add(model);
            }


            return View(models);
        }
        [Authorize]
        public async Task<IActionResult> Detail(int id)
        {

            Sharing sharing = await _sharingService.FindByIdAsync(id);
            SharingListModel model = new SharingListModel
            {
                    Id = sharing.Id,
                    Title = sharing.Title,
                    Description = sharing.Description,
                    SharingDate = sharing.SharingDate,
            };
            return View(model);
        }

      

       
    }
}
