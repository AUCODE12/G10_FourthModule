using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace botai;

internal class Program
{
    private static readonly string _token = "8144693012:AAFAIaFdB7tngMYge3bCrU81QjPp_vE7OP4";
    private static readonly TelegramBotClient _botClient = new TelegramBotClient(_token);
    private static readonly string _api = $"https://api.smtv.uz/gpt/?text=";
    static void Main(string[] args)
    {
        Console.WriteLine("start");
        using HttpClient client = new HttpClient();

        var cts = new CancellationTokenSource();

        _botClient.StartReceiving(
            HandleUpdateAsync,
            HandleErrorAsync,
            new ReceiverOptions { AllowedUpdates = { } },
            cts.Token
        );

        Console.ReadLine();
    }
    static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken token)
    {
        if (update.Message != null && update.Message.Text != null)
        {
            string text = update.Message.Text;
            string apiUrl = $"{_api}{Uri.EscapeDataString(text)}";

            using HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(apiUrl);

            await bot.SendTextMessageAsync(update.Message.Chat.Id, response);
        }
    }

    static Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken token)
    {
        Console.WriteLine($"Xatolik yuz berdi: {exception.Message}");
        return Task.CompletedTask;
    }
}
