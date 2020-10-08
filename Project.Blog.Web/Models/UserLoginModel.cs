using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Project.Blog.Web.Models
{
    public class UserLoginModel
    {
        [Display(Name="Username:")]
        [Required(ErrorMessage ="The username field is required.")]
        public string Username { get; set; }
        [Display(Name="Password:")]
        [Required(ErrorMessage ="The password field is required.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
