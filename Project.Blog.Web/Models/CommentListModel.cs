using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;


namespace Project.Blog.Web.Models
{
    public class CommentListModel
    {
		public int Id { get; set; }
		public string Description { get; set; }
		public DateTime CommentDate { get; set; }
		public int NumberOfLikes { get; set; }
		public DateTime LastModificationDate { get; set; }
		public int? SharingId { get; set; }
		public int? UserId { get; set; }
		public string CommentOwner { get; set; }

		public List<CommentUser> CommentUsers { get; set; }
		public bool isLiked { get; set; }



	}
}
