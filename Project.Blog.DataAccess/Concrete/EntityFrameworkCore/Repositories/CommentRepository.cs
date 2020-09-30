using Microsoft.EntityFrameworkCore;
using Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Context;
using Project.Blog.DataAccess.Interfaces;
using Project.Blog.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public async Task<List<Comment>> GetAllByDateAsync()
        {
            using var context = new BlogContext();

            DbSet<Comment> comments = context.Set<Comment>();
            return await comments.OrderByDescending(x => x.LastModificationDate).ToListAsync();
        }

        public async Task<List<Comment>> GetAllBySharingIdAsync(int sharingId)
        {
            using var context = new BlogContext();
            return await context.Set<Comment>().Where(s => s.SharingId == sharingId).OrderByDescending(x => x.LastModificationDate).ToListAsync();
        }
    }
}
