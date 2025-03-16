using BotLearnForExam.Dal.Entities;
using BotLearnForExam.Dal.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BotLearnForExam.Dal;

public class MainContext : DbContext
{
    //public MainContext(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        var connectionString = "Data Source=localhost\\SQLEXPRESS;User ID=sa;Password=1;Initial Catalog=BotLearnForExam;TrustServerCertificate=True;";
    //        optionsBuilder.UseSqlServer(connectionString);
    //    }
    //}
    public MainContext(DbContextOptions<MainContext> options) : base(options)
    {
    }

    public DbSet<BotUser> botUsers { get; set; }
    public DbSet<UserInfo> userInfos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BotUserConfiguration());
        modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
    }
}
