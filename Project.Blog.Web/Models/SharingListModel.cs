using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Blog.Web.Models
{
    public class SharingListModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public List<Comment> Comments { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime SharingDate { get; set; }
        public int NumberOfComments { get; set; }

    }
}
