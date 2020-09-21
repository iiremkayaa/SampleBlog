using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            /*builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Username).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Password).HasMaxLength(100).IsRequired();*/
            builder.Property(I => I.Name).HasMaxLength(100);
            builder.Property(I => I.LastName).HasMaxLength(100);
            //builder.Property(I => I.Email).HasMaxLength(100);
            builder.HasMany(I => I.Sharings).WithOne(I => I.User).HasForeignKey(I => I.UserId);


        }
    }
}
