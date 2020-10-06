using Microsoft.EntityFrameworkCore;
using Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Context;
using Project.Blog.DataAccess.Interfaces;
using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class CommentUserRepository : GenericRepository<CommentUser>, ICommentUserRepository
    {
       

        public async Task<List<CommentUser>> ReturnCommentUser(int commentId, int userId)
        {
            using var context = new BlogContext();
            return await context.Set<CommentUser>().Where(I => I.CommentId == commentId && I.UserId == userId).ToListAsync();

        }


    }
}
