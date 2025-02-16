using E_CommerceSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_CommerceSystem.Dal.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(u => u.UserId);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.HasOne(u => u.Cart)
            .WithOne(u => u.User)
            .HasForeignKey<Cart>(u => u.UserId);

        builder.HasMany(u => u.Reviews)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId);

        builder.HasMany(u => u.Orders)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId);

        builder.HasMany(u => u.Payments)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId);
    }
}
