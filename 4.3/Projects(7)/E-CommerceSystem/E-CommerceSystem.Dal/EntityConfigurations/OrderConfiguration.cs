using E_CommerceSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_CommerceSystem.Dal.EntityConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");

        builder.HasKey(x => x.OrderId);

        builder.HasOne(o => o.Payment)
            .WithOne(o => o.Order)
            .HasForeignKey<Order>(o => o.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(o => o.OrderProducts)
            .WithOne(o => o.Order)
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
