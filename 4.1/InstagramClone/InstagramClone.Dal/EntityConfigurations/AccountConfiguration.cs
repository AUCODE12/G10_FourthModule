using InstagramClone.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstagramClone.Dal.EntityConfigurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Account");

        builder.HasKey(a => a.AccountId);

        builder.Property(a => a.Username)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(a => a.Username)
            .IsUnique();

        builder.Property(a => a.Bio)
            .HasMaxLength(150);


        builder.HasMany(a => a.Posts)
            .WithOne(p => p.Account) 
            .HasForeignKey(p => p.AccountId);

     
        builder.HasMany(a => a.Comments)
            .WithOne(c => c.Account) 
            .HasForeignKey(c => c.AccountId);
    }
}
