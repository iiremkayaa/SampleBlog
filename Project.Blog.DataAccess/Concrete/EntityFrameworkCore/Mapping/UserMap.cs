using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Blog.Entities.Concrete;


namespace Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
      
            builder.Property(I => I.Name).HasMaxLength(100);
            builder.Property(I => I.LastName).HasMaxLength(100);
            builder.HasMany(I => I.Sharings).WithOne(I => I.User).HasForeignKey(I => I.UserId);
            builder.HasMany(I => I.Comments).WithOne(I => I.User).HasForeignKey(I => I.UserId);
            builder.HasMany(I => I.CommentUser).WithOne(I => I.User).HasForeignKey(I => I.UserId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
