using Project.Blog.Business.Interfaces;
using Project.Blog.DataAccess.Interfaces;
using Project.Blog.Entities.Concrete;


namespace Project.Blog.Business.Concrete
{
    public class CategoryService :GenericService<Category> ,ICategoryService
    {
        private readonly IGenericRepository<Category> _genericRepository;
        public CategoryService(IGenericRepository<Category> genericRepository):base(genericRepository)
        {
            _genericRepository = genericRepository;

        }

        
    }
}
