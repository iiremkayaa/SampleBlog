using Project.Blog.Entities.Concrete;
using Project.Blog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Blog.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class, ITable, new()
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
