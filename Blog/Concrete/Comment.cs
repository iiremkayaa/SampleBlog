using Project.Blog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Blog.Entities.Concrete
{
	public class Comment : ITable
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public DateTime CommentDate { get; set; }
		public int NumberOfLikes { get; set; }
		public DateTime LastModificationDate { get; set; }
		public int? SharingId { get; set; }
		public Sharing Sharing { get; set; }
		public int? UserId { get; set; }
		public User User { get; set; }
		public List<CommentUser> CommentUser { get; set; }
	}
}
