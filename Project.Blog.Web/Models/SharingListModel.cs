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
        public DateTime SharingDate { get; set; }
        public string UserName { get; set; }

    }
}
