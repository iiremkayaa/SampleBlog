using Project.Blog.Business.Interfaces;
using Project.Blog.DataAccess.Interfaces;


namespace Project.Blog.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
       
    }
}
