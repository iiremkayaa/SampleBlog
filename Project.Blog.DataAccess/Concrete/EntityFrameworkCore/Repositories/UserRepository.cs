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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public async Task<User> GetByUsernameAsync(string username)
        {

            using var context = new BlogContext();
            return await Task.FromResult(context.Users.Where(u => u.Username == username).FirstOrDefault());
        }
    }
}
