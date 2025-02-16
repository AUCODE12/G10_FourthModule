﻿using EventManagementSystem.Dal;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Api.Configurations;

public static class DatabaseConfiguration
{
    public static void ConfigureDatabase(this WebApplicationBuilder web)
    {
        var connectionString = web.Configuration.GetConnectionString("DatabaseConnection");
        web.Services.AddDbContext<MainContext>(options => options.UseSqlServer(connectionString));
    }
}
