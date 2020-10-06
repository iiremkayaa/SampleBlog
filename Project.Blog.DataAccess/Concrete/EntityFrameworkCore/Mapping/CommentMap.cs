using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder) {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Description).HasColumnType("ntext");
            builder.Property(I=>I.NumberOfLikes).HasDefaultValue(0);
            builder.Property(I=>I.LastModificationDate).HasDefaultValueSql("getdate()");
            builder.HasMany(I => I.CommentUser).WithOne(I => I.Comment).HasForeignKey(I => I.CommentId);

        }
    }
}
