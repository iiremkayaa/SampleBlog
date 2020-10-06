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
        private readonly ICommentUserRepository _commentUserRepository;
        public CommentService(ICommentUserRepository commentUserRepository,IGenericRepository<Comment> genericRepository, ICommentRepository commentRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
            _commentRepository = commentRepository;
            _commentUserRepository = commentUserRepository;
        }

        

        public async Task<List<Comment>> GetAllBySharingIdAsync(int id)
        {
            return await _commentRepository.GetAllBySharingIdAsync(id);
        }

        public async Task<List<Comment>> GetAllSortedByDateAsync()
        {
            return await _commentRepository.GetAllByDateAsync();
        }

        public async Task<bool> LikeComment(int commentId, int userId)
        {
           var result= await _commentUserRepository.ReturnCommentUser(commentId, userId);
            if (result.Count==0)
            {
                await _commentUserRepository.AddAsync(new CommentUser
                {
                    CommentId = commentId,
                    UserId = userId
                });
                return true;
            }
            else
            {
                await _commentUserRepository.DeleteAsync(result[0].Id);
                return false;
            }

        }

      
    }       
}
