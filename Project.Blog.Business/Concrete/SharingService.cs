using Project.Blog.Business.Interfaces;
using Project.Blog.DataAccess.Interfaces;
using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Blog.Business.Concrete
{
    public class SharingService: GenericService<Sharing>,ISharingService
    {
        private readonly IGenericRepository<Sharing> _genericRepository;
        private readonly ISharingRepository _sharingRepository;

        public SharingService(IGenericRepository<Sharing> genericRepository, ISharingRepository sharingRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
            _sharingRepository = sharingRepository;
        }

        public async Task<List<Sharing>> GetAllByCategoryIdAsync(int id)
        {
            return await _sharingRepository.GetAllByCategoryIdAsync(id);
           
        }
        public async Task<List<Sharing>> GetAllByUserIdAsync(int id)
        {
            return await _sharingRepository.GetAllByUserIdAsync(id);

        }

        public async Task<List<Sharing>> GetAllSortedByDateAsync()
        {
            return await _sharingRepository.GetAllByDateAsync();
        }

        public Task<List<Sharing>> SearchSharingAsync(string key)
        {
            return _sharingRepository.SearchSharingAsync(key);
        }
    }
}
