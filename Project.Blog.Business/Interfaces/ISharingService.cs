using Project.Blog.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Blog.Business.Interfaces
{
    public interface ISharingService :IGenericService<Sharing>
    {
        Task<List<Sharing>> GetAllByCategoryIdAsync(int id);
        Task<List<Sharing>> SearchSharingAsync(string key);
        Task<List<Sharing>> GetAllSortedByDateAsync();
        Task<List<Sharing>> GetAllByUserIdAsync(int id);
    }
}
