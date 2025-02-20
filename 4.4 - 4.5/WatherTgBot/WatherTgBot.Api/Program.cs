using Telegram.Bot;
using WatherTgBot.Api.Configurations;
using WatherTgBot.Api.Services;
using WatherTgBot.Bll.Services;
using WatherTgBot.Dal;
using WatherTgBot.Repository.Services;


namespace WatherTgBot.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.ConfigureDatabase();

            builder.Services.AddScoped<ITelegramUserService, TelegramUserService>();
            builder.Services.AddScoped<ITelegramUserRepository, TelegramUserRepository>();
            builder.Services.AddScoped<MainContext>();

            //builder.Services.AddSingleton<ITelegramBotClient>(new TelegramBotClient(""));
            //builder.Services.AddScoped<TelegramBotClient>();
            // Botni fon xizmat sifatida ishga tushirish
            //builder.Services.AddHostedService<BotBackgroundService>();

            builder.Services.AddSingleton<ITelegramBotClient>(new TelegramBotClient("8155349093:AAHT_1xd4X5Rlmx4MP8ut6oVRWUADSGYOx0"));
            builder.Services.AddScoped<ITelegramUserService, TelegramUserService>();
            builder.Services.AddHostedService<BotBackgroundService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
