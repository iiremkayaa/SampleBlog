using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime SharingDate { get; set; }
    }
}
