using Microsoft.EntityFrameworkCore;
using Wather7TgBot.Entities;

namespace Wather7TgBot;

public class BotDbContext : DbContext
{
    public DbSet<TelegramUser> TelegramUsers { get; set; }

    public BotDbContext(DbContextOptions<BotDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;User ID=sa;Password=1;Initial Catalog=Wather7TgBot;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TelegramUser>()
            .HasKey(u => u.BotUserId); // Primary Key

        modelBuilder.Entity<TelegramUser>()
            .Property(u => u.BotUserId)
            .ValueGeneratedOnAdd(); // Auto-increment

        base.OnModelCreating(modelBuilder);
    }
}
