using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Polling;
using Telegram.Bot.Exceptions;

namespace botapideepseek;

class Program
{
    private static readonly string TelegramBotToken = "8144693012:AAFAIaFdB7tngMYge3bCrU81QjPp_vE7OP4";
    private static readonly string DeepseekApiKey = "sk-9a1938bf5dbd4c7e92e98a9190ecf6e7";
    private static readonly string DeepseekApiUrl = "https://api.deepseek.com/v1/chat/completions";

    private static ITelegramBotClient _botClient;
    private static HttpClient _httpClient;

    static async Task Main(string[] args)
    {
        _botClient = new TelegramBotClient(TelegramBotToken);
        _httpClient = new HttpClient();

        var cts = new CancellationTokenSource();

        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };

        _botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            errorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );

        var me = await _botClient.GetMeAsync();
        Console.WriteLine($"Bot {me.Username} ishlayapti...");

        await Task.Delay(-1); // Botni to'xtatmaslik uchun
        cts.Cancel();
    }

    private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message)
            return;

        if (message.Text is not { } messageText)
            return;

        var chatId = message.Chat.Id;

        Console.WriteLine($"Foydalanuvchi xabari: {messageText}");

        var response = await GetDeepseekResponseAsync(messageText);

        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: response,
            cancellationToken: cancellationToken);
    }

    private static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var errorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Xatosi:\n{apiRequestException.ErrorCode}\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(errorMessage);
        return Task.CompletedTask;
    }

    private static async Task<string> GetDeepseekResponseAsync(string userMessage)
    {
        var requestData = new
        {
            model = "deepseek-chat",
            messages = new[]
            {
                new { role = "user", content = userMessage }
            }
        };

        var json = JsonSerializer.Serialize(requestData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", DeepseekApiKey);

        var response = await _httpClient.PostAsync(DeepseekApiUrl, content);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<JsonElement>(responseContent);
            return responseObject.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
        }
        else
        {
            return "Xatolik yuz berdi. Iltimos, keyinroq urinib ko'ring.";
        }
    }
}
