using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using Google.Apis.YouTube.v3.Data;
using System.Linq;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using MailKit;

class Program
{
    static string botToken = "YOUR_BOT_API_TOKEN"; // O'zingizning bot tokeningizni shu yerga qo'ying
    static string youtubeApiKey = "YOUR_YOUTUBE_API_KEY"; // YouTube API kalitini shu yerga qo'ying

    static TelegramBotClient botClient;

    static async Task Main(string[] args)
    {
        botClient = new TelegramBotClient(botToken);
        var me = await botClient.GetMeAsync();
        Console.WriteLine($"Bot {me.Username} yaratildi");

        botClient.OnMessage += Bot_OnMessage;

        botClient.StartReceiving()
        Console.WriteLine("Bot ishlayapti...");

        Console.ReadLine();
        botClient.StopReceiving();
    }

    private static async void Bot_OnMessage(object sender, MessageEventArgs e)
    {
        if (e.Message.Text == null) return;

        // "start" komandasi uchun
        if (e.Message.Text.ToLower() == "/start")
        {
            await botClient.SendTextMessageAsync(e.Message.Chat, "Salom! Men Musicqa botiman. Menga musiqa so‘rashingiz mumkin!");
        }

        // "musicqa" komandasi uchun
        else if (e.Message.Text.ToLower().StartsWith("/musicqa"))
        {
            string searchQuery = e.Message.Text.Substring(9).Trim(); // Foydalanuvchidan so'rovni olish
            if (!string.IsNullOrEmpty(searchQuery))
            {
                var videoUrl = await SearchYouTube(searchQuery);
                await botClient.SendTextMessageAsync(e.Message.Chat, $"Musiqa topildi: {videoUrl}");
            }
            else
            {
                await botClient.SendTextMessageAsync(e.Message.Chat, "Iltimos, musiqa nomini kiriting!");
            }
        }
    }

    private static async Task<string> SearchYouTube(string query)
    {
        var youtubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = youtubeApiKey,
            ApplicationName = GetType().ToString()
        });

        var searchListRequest = youtubeService.Search.List("snippet");
        searchListRequest.Q = query; // Musiqa nomi
        searchListRequest.MaxResults = 1;

        var searchListResponse = await searchListRequest.ExecuteAsync();

        var firstResult = searchListResponse.Items.FirstOrDefault();
        if (firstResult != null)
        {
            string videoUrl = $"https://www.youtube.com/watch?v={firstResult.Id.VideoId}";
            return videoUrl;
        }
        else
        {
            return "Musiqa topilmadi.";
        }
    }
}
