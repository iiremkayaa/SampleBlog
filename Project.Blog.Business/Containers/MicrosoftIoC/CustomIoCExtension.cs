﻿using Microsoft.Extensions.DependencyInjection;
using Project.Blog.Business.Concrete;
using Project.Blog.Business.Interfaces;
using Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Project.Blog.DataAccess.Interfaces;


namespace Project.Blog.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<ISharingRepository, SharingRepository>();
            services.AddScoped<ISharingService, SharingService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommentUserRepository, CommentUserRepository>();


        }
    }
}
