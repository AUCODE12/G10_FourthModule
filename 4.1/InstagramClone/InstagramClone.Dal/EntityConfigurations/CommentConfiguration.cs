using InstagramClone.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstagramClone.Dal.EntityConfigurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comment");

        builder.HasKey(c => c.CommentId);

        builder.Property(c => c.ContentText)
            .IsRequired(true)
            .HasMaxLength(200);

        builder.Property(c => c.WritingTime)
            .IsRequired(true);

        builder.HasOne(c => c.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.PostId)
            .IsRequired(true);

        builder.HasOne(c => c.ReplyToComment)
            .WithMany(c => c.Replies)
            .HasForeignKey(c => c.ReplyToCommentId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
