using Project.Blog.Business.Interfaces;
using Project.Blog.DataAccess.Interfaces;
using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Blog.Business.Concrete
{
    public class CommentService : GenericService<Comment>, ICommentService
    {
        private readonly IGenericRepository<Comment> _genericRepository;
        public CommentService(IGenericRepository<Comment> genericRepository):base(genericRepository)
        {
            _genericRepository = genericRepository;
        }
 
    }
}
