using CarRentalSystem.Dal;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Api.Configurations;

public static class DatabaseConfiguration
{
    public static void ConfigureDatabase(this WebApplicationBuilder app)
    {
        var connectionString = app.Configuration.GetConnectionString("DatabaseConnection");
        app.Services.AddDbContext<MainContext>(options => options.UseSqlServer(connectionString));
    }
}
