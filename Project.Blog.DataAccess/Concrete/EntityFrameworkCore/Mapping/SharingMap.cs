using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class SharingMap : IEntityTypeConfiguration<Sharing>
    {
        public void Configure(EntityTypeBuilder<Sharing> builder) {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Title).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Description).HasColumnType("ntext");
            builder.Property(I => I.SharingDate).HasDefaultValueSql("getdate()");
            builder.HasMany(I => I.Comments).WithOne(I => I.Sharing).HasForeignKey(I => I.SharingId).OnDelete(DeleteBehavior.Cascade);

        }
    }  
}
