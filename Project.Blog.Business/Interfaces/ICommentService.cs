using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Blog.Business.Interfaces
{
    public interface ICommentService :IGenericService<Comment>
    {
        Task<List<Comment>> GetAllBySharingIdAsync(int id);
        Task<List<Comment>> GetAllSortedByDateAsync();
        Task<bool> LikeComment(int commentId, int userId);
        Task<bool> isLiked(int commentId, int userId);
    }
}
