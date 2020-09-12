using Project.Blog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Blog.Entities.Concrete
{
	public class User : ITable
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public List<Sharing> Sharings { get; set; }
	}
}
