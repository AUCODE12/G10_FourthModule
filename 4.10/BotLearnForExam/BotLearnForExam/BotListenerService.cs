using BotLearnForExam.Bll.Services;
using BotLearnForExam.Dal.Entities;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotLearnForExam;

public class BotListenerService
{
    private static string botToken = "";
    private TelegramBotClient botClient = new TelegramBotClient(botToken);
    private readonly IBotUserService botUserService;

    public BotListenerService(IBotUserService botUserService)
    {
        this.botUserService = botUserService;
    }

    public async Task StartBot()
    {
        botClient.StartReceiving(
            HandleUpdateAsync,
            HandleErrorAsync
            );

        Console.WriteLine("Bot is running");

        Console.ReadKey();
    }

    private async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
    {
        if (update.Type == UpdateType.Message)
        {
            var user = update.Message.Chat;
            var message = update.Message;

            if (message.Text == "/start")
            {
                var saving = new BotUser()
                {
                     TelegramUserId = user.Id,
                     CreatedAt = DateTime.UtcNow,
                     FirstName = user.FirstName,
                     LastName = user.LastName,
                     IsBlocked = false,
                     UpdatedAt = DateTime.UtcNow,
                };

                await botUserService.AddBotUserAsync(saving);
                await StartMenu(botClient, user.Id);
                return;
            }
            if (message.Text == "My Information")
            {
                await MyInformationMenu(botClient, user.Id);
            }

        }
    }

    private async Task MyInformationMenu(ITelegramBotClient botClient, long userId)
    {
        var menu = new ReplyKeyboardMarkup(new[]
        {
            new[]
            {
                new KeyboardButton("First Name"),
                new KeyboardButton("Last Name"),
                new KeyboardButton("Email"),
            },
            new[]
            {
                new KeyboardButton("Phone Number"),
                new KeyboardButton("Address"),
                new KeyboardButton("Summary"),
            }
        })
        {
            ResizeKeyboard = true
        };

        var infoText = "Barcha malumotlaringizni shu yerdan o'zgartirishingiz mumkin";

        botClient.SendTextMessageAsync(
            chatId: userId,
            text: infoText,
            parseMode: ParseMode.Markdown,
            replyMarkup: menu
            );
    }

    private async Task StartMenu(ITelegramBotClient botClient, long userId)
    {
        var menu = new ReplyKeyboardMarkup(new[]
        {
            new[]
            {
                new KeyboardButton("My Information"),
            }
        })
        {
            ResizeKeyboard = true
        };

        var infoText = "'My Information' bo'limidan barcha malumotlaringizni kiritishingiz mumkin!";

        await botClient.SendTextMessageAsync(
            chatId: userId,
            text: infoText,
            parseMode: ParseMode.Markdown,
            replyMarkup: menu
            );
    }

    private async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine();
    }
}
