using Microsoft.EntityFrameworkCore;
using Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Context;
using Project.Blog.DataAccess.Interfaces;
using Project.Blog.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class SharingRepository : GenericRepository<Sharing>, ISharingRepository
    {
        public async Task<List<Sharing>> GetAllByCategoryIdAsync(int id)
        {
            using var context = new BlogContext();
            return await context.Set<Sharing>().OrderByDescending(x => x.SharingDate).Where(s => s.CategoryId == id).ToListAsync();
        }
        public async Task<List<Sharing>> GetAllByUserIdAsync(int id)
        {
            using var context = new BlogContext();
            return await context.Set<Sharing>().OrderByDescending(x => x.SharingDate).Where(s => s.UserId == id).ToListAsync();
        }


        public async Task<List<Sharing>> SearchSharingAsync(string key)
        {
            using var context = new BlogContext();
            return await context.Set<Sharing>().OrderByDescending(x=>x.SharingDate).Where(s => s.Title.Contains(key) || s.Description.Contains(key)).ToListAsync();
        }

        public async Task<List<Sharing>> GetAllByDateAsync()
        {
            using var context = new BlogContext();

            DbSet<Sharing> sharings= context.Set<Sharing>();
            return await  sharings.OrderByDescending(x => x.SharingDate).ToListAsync();

            
        }
    }
}
