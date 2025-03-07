using Microsoft.EntityFrameworkCore;
using RamazonTaqvimiBot.Dal.Entities;
using RamazonTaqvimiBot.Dal.EntityConfigurations;

namespace RamazonTaqvimiBot.Dal;

public class MainContext : DbContext
{
    public MainContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;User ID=sa;Password=1;Initial Catalog=RamazonTaqvimiBotDb;TrustServerCertificate=True;");
        }
    }
    

    public DbSet<UserTg> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserTgConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
