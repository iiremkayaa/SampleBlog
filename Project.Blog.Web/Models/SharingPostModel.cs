using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Blog.Web.Models
{
    public class SharingPostModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
       
        public int? CategoryId { get; set; }
        public DateTime SharingDate { get; set; }
    }
}
