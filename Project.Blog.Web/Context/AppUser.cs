using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Blog.Web.Context
{
    public class AppUser :IdentityUser<int>
    {
        public string Gender { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
