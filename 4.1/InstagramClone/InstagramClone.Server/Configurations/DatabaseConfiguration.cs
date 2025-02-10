using InstagramClone.Dal;
using Microsoft.EntityFrameworkCore;

namespace InstagramClone.Server.Configurations;

public static class DatabaseConfiguration
{
    public static void ConfigureDatabase(this WebApplicationBuilder builder)
    {
        var connectionStirng = builder.Configuration.GetConnectionString("DatabaseConnection");
        builder.Services.AddDbContext<MainContext>(options =>
            options.UseSqlServer(connectionStirng));
    }
}
