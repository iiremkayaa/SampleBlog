using Project.Blog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Blog.Entities.Concrete
{
    public class Category :ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Sharing> Sharings { get; set; }

    }
}
