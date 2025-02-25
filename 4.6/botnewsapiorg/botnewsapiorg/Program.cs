using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace botnewsapiorg;

class Program
{
    private static readonly string botToken = "8144693012:AAFAIaFdB7tngMYge3bCrU81QjPp_vE7OP4";
    private static readonly string newsApiKey = "f96be762bc774c3c85b220c705f2f55f";
    private static readonly string newsApiUrl = "https://newsapi.org/v2/top-headlines?country=us&apiKey=" + newsApiKey;

    static async Task Main()
    {
        var botClient = new TelegramBotClient(botToken);
        botClient.StartReceiving(UpdateHandler, ErrorHandler);

        Console.WriteLine("Bot ishga tushdi...");
        await Task.Delay(-1);
    }

    private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, System.Threading.CancellationToken cancellationToken)
    {
        if (update.Message != null)
        {
            var chatId = update.Message.Chat.Id;
            var messageText = update.Message.Text;

            if (messageText == "/start")
            {
                var replyKeyboard = new ReplyKeyboardMarkup(new[]
                {
                    new KeyboardButton[] { "Kun yangiliklari" }
                })
                {
                    ResizeKeyboard = true
                };

                await botClient.SendTextMessageAsync(chatId, "Salom! Bugungi yangiliklarni olish uchun tugmani bosing.", replyMarkup: replyKeyboard);
            }
            else if (messageText == "Kun yangiliklari")
            {
                string news = await GetNewsAsync();
                await botClient.SendTextMessageAsync(chatId, news, parseMode: ParseMode.Html);
            }
        }
    }

    private static async Task<string> GetNewsAsync()
    {
        using var client = new HttpClient();
        var response = await client.GetStringAsync(newsApiUrl);
        var json = JsonSerializer.Deserialize<NewsResponse>(response);

        if (json?.Articles == null || json.Articles.Length == 0)
            return "Bugun yangiliklar topilmadi.";

        return string.Join("\n\n", json.Articles.Take(5).Select(a => $"📰 <b>{a.Title}</b>\n🔗 <a href='{a.Url}'>Batafsil</a>"));
    }

    private static Task ErrorHandler(ITelegramBotClient botClient, Exception exception, System.Threading.CancellationToken cancellationToken)
    {
        Console.WriteLine($"Xatolik: {exception.Message}");
        return Task.CompletedTask;
    }
}

public class NewsResponse
{
    public Article[] Articles { get; set; }
}

public class Article
{
    public string Title { get; set; }
    public string Url { get; set; }
}
