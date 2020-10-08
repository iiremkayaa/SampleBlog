using Project.Blog.Entities.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Blog.Business.Interfaces
{
    public interface IGenericService<T> where T:class,ITable,new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> FindByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(int id);
    }
}
