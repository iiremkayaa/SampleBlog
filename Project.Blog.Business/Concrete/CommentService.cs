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
        private readonly ICommentRepository _commentRepository;
        public CommentService(IGenericRepository<Comment> genericRepository, ICommentRepository commentRepository) :base(genericRepository)
        {
            _genericRepository = genericRepository;
            _commentRepository = commentRepository;
        }

        public async Task<List<Comment>> GetAllBySharingIdAsync(int id)
        {
           return await _commentRepository.GetAllBySharingIdAsync(id);
        }
    }
}
