using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WatherTgBot.Dal.Entities;

namespace WatherTgBot.Dal.EntityConfigurations;

public class TelegramUserConfiguration : IEntityTypeConfiguration<TelegramUser>
{
    public void Configure(EntityTypeBuilder<TelegramUser> builder)
    {
        builder.ToTable("TelegramUser");

        builder.HasKey(x => x.BotUserId);
    }
}
