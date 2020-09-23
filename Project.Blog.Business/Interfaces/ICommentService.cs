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
    }
}
