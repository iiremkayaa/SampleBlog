using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Project.Blog.Web.Models
{
    public class UserRegisterModel 
    {
        [Display(Name="Username:")]
        [Required(ErrorMessage= "The username field is required.")]
        public string Username { get; set; }

        [Display(Name="Password:")]
        [Required(ErrorMessage = "The password field is required.")]
        public string Password { get; set; }

        [Display(Name="Confirm Password:")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [Required(ErrorMessage = "The confirm password field is required.")]
        public string ConfirmPassword { get; set; }

        [Display(Name="Name:")]
        [Required(ErrorMessage = "The name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The last name field is required.")]
        [Display(Name="Last name:")]
        public string LastName { get; set; }

        [Display(Name="Email:")]
        [Required(ErrorMessage = "The email field is required.")]
        public string Email { get; set; }
    }
}
