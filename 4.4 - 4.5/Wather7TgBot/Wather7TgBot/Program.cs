using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Microsoft.EntityFrameworkCore;
using Wather7TgBot.Entities;

namespace Wather7TgBot;

internal class Program
{
    private static readonly string _botToken = "8155349093:AAHT_1xd4X5Rlmx4MP8ut6oVRWUADSGYOx0";
    private static readonly TelegramBotClient _bot = new TelegramBotClient(_botToken);

    static async Task Main()
    {
        using var cts = new CancellationTokenSource();
        var receiverOptions = new ReceiverOptions { AllowedUpdates = { } };

        _bot.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, cts.Token);

        Console.WriteLine("Bot ishga tushdi...");
        //await Task.Delay(-1); // Long Polling davomiy ishlashi uchun
    }

    private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Type != UpdateType.Message || update.Message!.Type != MessageType.Text)
            return;

        var message = update.Message;
        var chatId = message.Chat.Id;

        if (message.Text == "/start")
        {
            await RegisterUser(message);
            await botClient.SendTextMessageAsync(chatId, "Assalomu alaykum! Ushbu bot haqida ma’lumot:\n\nBu bot sizning ma’lumotlaringizni bazaga saqlaydi va sizga xizmat ko‘rsatadi.");
        }
    }

    private static async Task RegisterUser(Message message)
    {
        var options = new DbContextOptionsBuilder<BotDbContext>()
            .UseSqlServer("Data Source=localhost\\SQLEXPRESS;User ID=sa;Password=1;Initial Catalog=Wather7TgBot;TrustServerCertificate=True;")
            .Options;

        using var db = new BotDbContext(options);

        var existingUser = await db.TelegramUsers.FirstOrDefaultAsync(u => u.TelegramUserId == message.Chat.Id);

        if (existingUser == null)
        {
            var newUser = new TelegramUser
            {
                CreatedAt = DateTime.UtcNow,
                IsBlocked = false,
                PhoneNumber = message.Contact?.PhoneNumber,
                TelegramUserId = message.Chat.Id,
                FirstName = message.Chat.FirstName,
                LastName = message.Chat.LastName,
                Username = message.Chat.Username,
            };

            db.TelegramUsers.Add(newUser);
            await db.SaveChangesAsync();
            Console.WriteLine($"Yangi foydalanuvchi qo‘shildi: {newUser.FirstName} ({newUser.TelegramUserId})");
        }
        else
        {
            Console.WriteLine($"Foydalanuvchi allaqachon mavjud: {existingUser.FirstName} ({existingUser.TelegramUserId})");
        }
    }

    private static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Xatolik yuz berdi: {exception.Message}");
        return Task.CompletedTask;
    }
}
