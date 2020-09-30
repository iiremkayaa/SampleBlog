using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Blog.Web.Models
{
    public class UserLoginModel
    {
        [Display(Name="Username:")]
        [Required(ErrorMessage ="Username must not be empty.")]
        public string Username { get; set; }
        [Display(Name="Password:")]
        [Required(ErrorMessage ="Password must not be empty.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
