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
            CreateMap<CategoryListModel, Category>();
            CreateMap<Category, CategoryListModel>();

            CreateMap<CommentListModel, Comment>();
            CreateMap<Comment, CommentListModel>();

            CreateMap<SharingListModel, Sharing>();
            CreateMap<Sharing, SharingListModel>();

            CreateMap<UserListModel, User>();
            CreateMap<User, UserListModel>();

            CreateMap<SharingPostModel, Sharing>();
            CreateMap<Sharing, SharingPostModel>();
        }
    }
}
