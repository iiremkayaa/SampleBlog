using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Blog.DataAccess.Interfaces
{
    public interface ICommentRepository :IGenericRepository<Comment>
    {
    }
}
