using Microsoft.EntityFrameworkCore;
using Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Context;
using Project.Blog.DataAccess.Interfaces;
using Project.Blog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, ITable, new()
    {

        public async Task AddAsync(T entity)
        {
            using var context = new BlogContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            using var context = new BlogContext();
            var entity = await context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
            
        }
        public async Task<T> GetAsync(int id)
        {
            using var context = new BlogContext();
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            using var context = new BlogContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            using var context = new BlogContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }


       
    }
}
