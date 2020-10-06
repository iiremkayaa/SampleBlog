using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Blog.DataAccess.Interfaces
{
    public interface ICommentUserRepository : IGenericRepository<CommentUser>
    {
        Task<List<CommentUser>> ReturnCommentUser(int commentId,int userId);
    }
}
