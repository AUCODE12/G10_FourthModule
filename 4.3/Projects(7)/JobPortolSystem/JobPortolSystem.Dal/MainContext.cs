using Microsoft.EntityFrameworkCore;

namespace JobPortolSystem.Dal;

public class MainContext : DbContext
{
    //public DbSet<> entities { get; set; }

    public MainContext(DbContextOptions options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
