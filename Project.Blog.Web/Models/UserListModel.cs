using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Blog.Web.Models
{
    public class UserListModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        //public string Password { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        //public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public List<Sharing> Sharings { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
