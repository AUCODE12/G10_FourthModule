using E_CommerceSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_CommerceSystem.Dal.EntityConfigurations;

class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
{
    public void Configure(EntityTypeBuilder<OrderProduct> builder)
    {
        builder.ToTable("OrderProduct");

        builder.HasKey(c => c.OrderProductId);

        builder.Property(c => c.Quantity)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Price)
            .IsRequired()
            .HasMaxLength(200);
    }
}
