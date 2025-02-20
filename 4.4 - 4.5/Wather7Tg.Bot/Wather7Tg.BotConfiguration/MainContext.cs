using Microsoft.EntityFrameworkCore;
using Wather7Tg.BotConfiguration.Entities;
using Wather7Tg.BotConfiguration.EntityConfigurations;

namespace Wather7Tg.BotConfiguration;

public class MainContext : DbContext
{
    public DbSet<TelegramUser> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;User ID=sa;Password=1;Initial Catalog=Wather7Tg.Bot;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TelegramUserConfiguration());
    }
}
