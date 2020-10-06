using Microsoft.AspNetCore.Identity;
using Project.Blog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Blog.Entities.Concrete
{
	public class User :  IdentityUser<int>
	{
		public string Gender { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public List<Sharing> Sharings { get; set; }
		public List<Comment> Comments { get; set; }
		public List<CommentUser> CommentUser { get; set; }
	}
}
