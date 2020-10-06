using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Blog.Web.Models
{
    public class CommentListModel
    {
		public int Id { get; set; }
		public string Description { get; set; }
		public DateTime CommentDate { get; set; }
		public int NumberOfLikes { get; set; }
		public DateTime LastModificationDate { get; set; }
		public string UserName { get; set; }

		public List<CommentUser> CommentUsers { get; set; }
		public string isLiked { get; set; }



	}
}
