using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace botlearn;

internal class Program
{
    private static string token = "8144693012:AAFAIaFdB7tngMYge3bCrU81QjPp_vE7OP4"; // Your bot token
    private static TelegramBotClient telegramBotClient; // Create a new instance of the TelegramBotClient class
    private static Queue<long> waitingUsers = new Queue<long>();
    private static Dictionary<long, long> activeChats = new Dictionary<long, long>();

    static void Main(string[] args)
    {
        telegramBotClient = new TelegramBotClient(token);

        telegramBotClient.StartReceiving(UpdateHandler, PollingErrorHandler);

        Console.WriteLine("Bot is running...");
        Console.ReadLine();
    }


    private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message != null)
        {
            long userId = update.Message.Chat.Id;
            string text = update.Message.Text;

            try
            {
                Console.WriteLine(update.Message.Chat.FirstName + " " + update.Message.Text);

                if (text == "/start")
                {
                    await SendStartMenu(userId);
                }
                else if (text == "Ananim Chating")
                {
                    await AnanimChating(userId);
                }
                else if (text == "Start Chatting")
                {
                    await HandleStartChatting(userId);
                }
                else if (text == "Stop Chatting")
                {
                    await HandleStopChatting(userId);
                }
                else
                {
                    await ForwardMessage(userId, text);
                }
            }
            catch (Exception ex)
            {
                await ErrorHandler(botClient, ex, userId, cancellationToken);
            }
        }
    }


    private static async Task SendStartMenu(long userId)
    {
        var replyMarkup = new ReplyKeyboardMarkup(new[]
        {
            new KeyboardButton("Ananim Chatting"),
        })
        {
            ResizeKeyboard = true
        };

        await telegramBotClient.SendTextMessageAsync(userId, "Welcome!", replyMarkup: replyMarkup);
    }


    private static async Task AnanimChating(long userId)
    {
        var replyMarkup = new ReplyKeyboardMarkup(new[]
        {
            new KeyboardButton("Start Chatting"),
            new KeyboardButton("Stop Chatting")
        })
        {
            ResizeKeyboard = true
        };

        await telegramBotClient.SendTextMessageAsync(userId, "Press 'Start Chatting' to begin.!", replyMarkup: replyMarkup);
    }

    private static async Task HandleStartChatting(long userId)
    {
        if (activeChats.ContainsKey(userId))
        {
            await telegramBotClient.SendTextMessageAsync(userId, "You are already in a chat.");
            return;
        }

        if (waitingUsers.Count > 0)
        {
            long pairedUserId = waitingUsers.Dequeue();
            activeChats[userId] = pairedUserId;
            activeChats[pairedUserId] = userId;

            await telegramBotClient.SendTextMessageAsync(userId, "You are now connected to a stranger.");
            await telegramBotClient.SendTextMessageAsync(pairedUserId, "You are now connected to a stranger.");
        }
        else
        {
            waitingUsers.Enqueue(userId);
            await telegramBotClient.SendTextMessageAsync(userId, "Waiting for a stranger to connect...");
        }
    }

    private static async Task HandleStopChatting(long userId)
    {
        if (activeChats.ContainsKey(userId))
        {
            long pairedUserId = activeChats[userId];
            activeChats.Remove(userId);
            activeChats.Remove(pairedUserId);

            await telegramBotClient.SendTextMessageAsync(userId, "You have left the chat.");
            await telegramBotClient.SendTextMessageAsync(pairedUserId, "Your chat partner has left the chat.");

            await SendStartMenu(userId);
            await SendStartMenu(pairedUserId);
        }
        else
        {
            await telegramBotClient.SendTextMessageAsync(userId, "You are not in a chat.");
        }
    }
        
    private static async Task ForwardMessage(long userId, string text)
    {
        if (activeChats.ContainsKey(userId))
        {
            long pairedUserId = activeChats[userId];
            await telegramBotClient.SendTextMessageAsync(pairedUserId, text);
        }
        else
        {
            await telegramBotClient.SendTextMessageAsync(userId, "You are not in a chat. Press 'Start Chatting' to begin.");
        }
    }


    private static async Task ErrorHandler(ITelegramBotClient botClient, Exception exception, long chatId, CancellationToken cancellationToken)
    {
        var path = @"C:\Users\777\Downloads\windows-error-sound-effect-35894.mp3";

        if (!File.Exists(path))
        {
            Console.WriteLine("Xatolik: Fayl topilmadi!");
            return;
        }

        using var stream = File.OpenRead(path);
        Console.WriteLine($"Error: {exception.Message}");

        await botClient.SendAudioAsync(
            chatId: chatId,
            audio: InputFile.FromStream(stream, "windows-error-sound-effect-35894.mp3"),
            caption: "⚠️ Xatolik yuz berdi!"
        );
    }

    private static Task PollingErrorHandler(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Polling Error: {exception.Message}");
        return Task.CompletedTask;
    }
}
