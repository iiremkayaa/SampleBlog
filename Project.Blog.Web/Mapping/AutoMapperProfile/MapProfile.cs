using AutoMapper;
using Project.Blog.Entities.Concrete;
using Project.Blog.Web.Models;


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
