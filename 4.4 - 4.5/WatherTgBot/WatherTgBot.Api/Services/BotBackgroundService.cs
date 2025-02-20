using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot;
using WatherTgBot.Bll.DTOs;
using WatherTgBot.Bll.Services;
using Telegram.Bot.Types;

namespace WatherTgBot.Api.Services;

public class BotBackgroundService : BackgroundService
{
    private readonly ITelegramBotClient _botClient;
    private readonly IServiceProvider _serviceProvider; // Scoped servislarga to'g'ri kirish uchun

    public BotBackgroundService(ITelegramBotClient botClient, IServiceProvider serviceProvider)
    {
        _botClient = botClient;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = new[] { UpdateType.Message }
        };

        _botClient.StartReceiving(
            HandleUpdateAsync,
            HandleErrorAsync,
            receiverOptions,
            stoppingToken);

        await Task.Delay(-1, stoppingToken);
    }

    private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message) return;
        if (message.Text is not { } messageText) return;

        var chat = message.Chat;

        using (var scope = _serviceProvider.CreateScope()) // Yangi scope yaratish
        {
            var telegramUserService = scope.ServiceProvider.GetRequiredService<ITelegramUserService>();

            if (messageText == "/start")
            {
                var users = await telegramUserService.GetAllUsers();
                if (users.Any(u => u.TelegramUserId == chat.Id))
                {
                    await botClient.SendTextMessageAsync(chat.Id, "Siz allaqachon ro‘yxatdan o‘tganingiz!", cancellationToken: cancellationToken);
                    return;
                }

                await botClient.SendTextMessageAsync(chat.Id, "Assalomu alaykum, botimizga xush kelibsiz! \n\n" +
                    "Botimiz orqali siz havo ma'lumotlarini olishingiz mumkin. \n\n" +
                    "Iltimos, quyidagi tugmani bosing va sizning lokatsiyangizni yuboring.", cancellationToken: cancellationToken);

                await telegramUserService.AddUser(new TelegramUserDto
                {
                    IsBlocked = false,
                    PhoneNumber = null,
                    TelegramUserId = chat.Id,
                    FirstName = chat.FirstName,
                    LastName = chat.LastName,
                    Username = chat.Username,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var keyboard = new ReplyKeyboardMarkup(new[]
                {
                    new KeyboardButton[] { new KeyboardButton("📍 Lokatsiyani yuborish") { RequestLocation = true } }
                })
                {
                    ResizeKeyboard = true,
                    OneTimeKeyboard = true
                };

                await botClient.SendTextMessageAsync(chat.Id, "Lokatsiyangizni yuboring:", replyMarkup: keyboard, cancellationToken: cancellationToken);
            }
        }
    }

    private Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Xatolik: {exception.Message}");
        return Task.CompletedTask;
    }
}

