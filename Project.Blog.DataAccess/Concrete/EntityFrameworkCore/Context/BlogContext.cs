using Microsoft.EntityFrameworkCore;
using Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class BlogContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=BlogProjectDb;integrated security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new SharingMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Sharing> Sharings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
