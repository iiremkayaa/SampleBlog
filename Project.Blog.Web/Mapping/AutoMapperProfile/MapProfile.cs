using AutoMapper;
using Project.Blog.Dto.DTOs.CategoryDtos;
using Project.Blog.Entities.Concrete;
using Project.Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Blog.Web.Mapping.AutoMapperProfile
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            //CreateMap<CategoryListDtos,Category >();
        }
    }
}
