using E_CommerceSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_CommerceSystem.Dal.EntityConfigurations;

public class CartProductConfigurations : IEntityTypeConfiguration<CartProduct>
{
    public void Configure(EntityTypeBuilder<CartProduct> builder)
    {
        builder.ToTable("CartProduct");

        builder.HasKey(c => c.CartProductId);

        builder.Property(c => c.Quentity)
            .IsRequired()
            .HasMaxLength(200);
    }
}
