using Microsoft.EntityFrameworkCore;
using WatherTgBot.Dal.Entities;

namespace WatherTgBot.Dal;

public class MainContext : DbContext
{
    public DbSet<TelegramUser> TelegramUsers { get; set; } 

    public MainContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
