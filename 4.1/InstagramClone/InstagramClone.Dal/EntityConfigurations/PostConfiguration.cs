using InstagramClone.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstagramClone.Dal.EntityConfigurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Post");

        builder.HasKey(p => p.PostId);

        builder.Property(p => p.PostType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.SetTime)
            .IsRequired();

        builder.HasMany(p => p.Comments)
            .WithOne(c => c.Post) 
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
