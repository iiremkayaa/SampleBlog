using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Blog.DataAccess.Interfaces
{
    public interface ICommentRepository :IGenericRepository<Comment>
    {
        Task<List<Comment>> GetAllBySharingIdAsync(int sharingId);
        Task<List<Comment>> GetAllByDateAsync();
    }
}
