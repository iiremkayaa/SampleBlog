using Project.Blog.Business.Concrete;
using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Blog.Business.Interfaces
{
    public interface ICommentUserService :IGenericService<CommentUser>
    {
        Task<List<CommentUser>> AddCommentUser(int commentId, int userId);
        Task<List<CommentUser>> RemoveCommentUser(int commentId, int userId);
    }
}
