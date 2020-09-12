using Project.Blog.Business.Interfaces;
using Project.Blog.DataAccess.Interfaces;
using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Blog.Business.Concrete
{
    public class SharingService:GenericService<Sharing>,ISharingService
    {
        private readonly IGenericRepository<Sharing> _genericRepository;
        public SharingService(IGenericRepository<Sharing> genericRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
