using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Blog.Web.Models
{
    public class UserRegisterModel 
    {
        [Display(Name="Username:")]
        [Required(ErrorMessage="Username must not be empty.")]
        public string Username { get; set; }

        [Display(Name="Password:")]
        [Required(ErrorMessage ="Password must not be empty.")]
        public string Password { get; set; }

        [Display(Name="Confirm Password:")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [Required(ErrorMessage ="Confirm password must not be empty.")]
        public string ConfirmPassword { get; set; }

        [Display(Name="Name:")]
        [Required(ErrorMessage = "Name must not be empty.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Last Name must not be empty.")]
        [Display(Name="Last name:")]
        public string LastName { get; set; }

        [Display(Name="Email:")]
        [Required(ErrorMessage = "Email must not be empty.")]
        public string Email { get; set; }
    }
}
