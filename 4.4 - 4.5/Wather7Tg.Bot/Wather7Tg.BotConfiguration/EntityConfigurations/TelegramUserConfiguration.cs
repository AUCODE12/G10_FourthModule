using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wather7Tg.BotConfiguration.Entities;

namespace Wather7Tg.BotConfiguration.EntityConfigurations;

public class TelegramUserConfiguration : IEntityTypeConfiguration<TelegramUser>
{
    public void Configure(EntityTypeBuilder<TelegramUser> builder)
    {
        builder.ToTable("User");

        builder.HasKey(u => u.BotUserId);
    }
}
