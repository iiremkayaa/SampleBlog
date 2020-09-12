using Project.Blog.Business.Interfaces;
using Project.Blog.DataAccess.Interfaces;
using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
