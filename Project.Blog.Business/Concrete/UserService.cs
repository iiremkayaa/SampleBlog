using Project.Blog.Business.Interfaces;
using Project.Blog.DataAccess.Interfaces;
using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Blog.Business.Concrete
{
    public class UserService :GenericService<User>,IUserService
    {
        private readonly IGenericRepository<User> _genericRepository;
        public UserService(IGenericRepository<User> genericRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
