using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class BlogContext :IdentityDbContext<User,Role,int>
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies(true);
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=BlogProjectDb;integrated security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new SharingMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CommentUserMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            
            
            
           
            base.OnModelCreating(modelBuilder);

           
        }
       
        public DbSet<Sharing> Sharings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentUser> CommentUsers { get; set; }
    }
}
