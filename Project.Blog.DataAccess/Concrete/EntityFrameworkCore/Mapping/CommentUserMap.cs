using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CommentUserMap : IEntityTypeConfiguration<CommentUser>
    {
        public void Configure(EntityTypeBuilder<CommentUser> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.HasIndex(I => new { I.UserId, I.CommentId }).IsUnique();
            builder.HasOne(bc => bc.Comment).WithMany(b => b.CommentUser).HasForeignKey(bc => bc.CommentId);
            builder.HasOne(bc => bc.User).WithMany(c => c.CommentUser).HasForeignKey(bc => bc.UserId);
        }
    }
}
