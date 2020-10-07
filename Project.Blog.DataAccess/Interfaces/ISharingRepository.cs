using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Blog.DataAccess.Interfaces
{
    public interface ISharingRepository :IGenericRepository<Sharing>
    {
        Task<List<Sharing>> GetAllByCategoryIdAsync(int categoryId);
        Task<List<Sharing>> SearchSharingAsync(string key);
        Task<List<Sharing>> GetAllByDateAsync();
        Task<List<Sharing>> GetAllByUserIdAsync(int id);
    }
}
