using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RamazonTaqvimiBot.Dal.Entities;

namespace RamazonTaqvimiBot.Dal.EntityConfigurations;

public class UserTgConfiguration : IEntityTypeConfiguration<UserTg>
{
    public void Configure(EntityTypeBuilder<UserTg> builder)
    {
        builder.ToTable("User");

        builder.HasKey(u => u.BotUserId);

        builder.Property(u => u.TelegramUserId)
            .IsRequired();

        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.LastName)
            .HasMaxLength(100);

        builder.Property(u => u.Username)
            .HasMaxLength(50);

        builder.Property(u => u.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(u => u.Location)
            .IsRequired();

        builder.Property(u => u.IsBlocked)
            .HasDefaultValue(false);
    }
}
