using Project.Blog.DataAccess.Interfaces;
using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class SharingRepository :GenericRepository<Sharing> ,ISharingRepository
    {
    }
}
