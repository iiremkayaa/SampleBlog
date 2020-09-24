using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Blog.Web.Models
{
    public class SharingPostModel
    {
        [Display(Name = "Title:")]
        [Required(ErrorMessage = "Title must not be empty.")]
        public string Title { get; set; }
        [Display(Name = "Description:")]
        [Required(ErrorMessage = "Description must not be empty.")]
        public string Description { get; set; }
        public int? UserId { get; set; }
       
        public int? CategoryId { get; set; }
        public DateTime SharingDate { get; set; }
    }
}
