using BotDal.Entity;
using BotDal.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BotDal;

public class MainContext : DbContext
{
    public DbSet<TelegramUser> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;User ID=sa;Password=1;Initial Catalog=Bot;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TelegramUserConfiguration());
    }
}
