using Project.Blog.Business.Interfaces;
using Project.Blog.DataAccess.Interfaces;
using Project.Blog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Blog.Business.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : class, ITable, new()
    {
        private readonly IGenericRepository<T> _genericRepository;
        public GenericService(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task AddAsync(T entity)
        {
            await _genericRepository.AddAsync(entity);
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _genericRepository.GetAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await  _genericRepository.GetAllAsync();
        }

        public async Task RemoveAsync(int id)
        {
            await _genericRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
           await _genericRepository.UpdateAsync(entity);
        }
    }
}
