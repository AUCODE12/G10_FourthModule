using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Collections.Concurrent;

public class Program
{
    private static readonly string BotToken = "7663585044:AAGfPoafl1FLjj134OWQGFaTtJVmxhOFSrk";
    private static readonly TelegramBotClient bot = new(BotToken);
    private static readonly ConcurrentQueue<long> waitingQueue = new();
    private static readonly ConcurrentDictionary<long, long> activeChats = new();

    static async Task Main()
    {
        bot.StartReceiving(UpdateHandler, ErrorHandler);
        Console.WriteLine("Bot ishga tushdi!");
        await Task.Delay(-1);
    }

    private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Type != UpdateType.Message || update.Message == null) return;

        var message = update.Message;
        var userId = message.Chat.Id;

        if (message.Text == "/start")
        {
            if (!activeChats.ContainsKey(userId))
            {
                await MatchUser(userId);
            }
        }
        else if (activeChats.TryGetValue(userId, out var partnerId))
        {
            await ForwardMessage(userId, partnerId, message);
        }
        else
        {
            await botClient.SendTextMessageAsync(userId, "Sizga sherik topilmadi. Iltimos, kuting...");
        }
    }

    private static async Task MatchUser(long userId)
    {
        if (waitingQueue.TryDequeue(out var partnerId))
        {
            activeChats[userId] = partnerId;
            activeChats[partnerId] = userId;
            await bot.SendTextMessageAsync(userId, "Sizga sherik topildi! Yozishni boshlang.");
            await bot.SendTextMessageAsync(partnerId, "Sizga sherik topildi! Yozishni boshlang.");
        }
        else
        {
            waitingQueue.Enqueue(userId);
            await bot.SendTextMessageAsync(userId, "Siz navbatdasiz. Sherik topilishini kuting...");
        }
    }

    private static async Task ForwardMessage(long senderId, long receiverId, Message message)
    {
        if (message.Type == MessageType.Text)
        {
            await bot.SendTextMessageAsync(receiverId, message.Text);
        }
        else if (message.Type == MessageType.Photo)
        {
            var photo = message.Photo.LastOrDefault()?.FileId;
            if (photo != null) await bot.SendPhotoAsync(receiverId, photo);
        }
        else if (message.Type == MessageType.Audio)
        {
            await bot.SendAudioAsync(receiverId, message.Audio.FileId);
        }
        else if (message.Type == MessageType.Voice)
        {
            await bot.SendVoiceAsync(receiverId, message.Voice.FileId);
        }
        else if (message.Type == MessageType.Video)
        {
            await bot.SendVideoAsync(receiverId, message.Video.FileId);
        }
    }

    private static Task ErrorHandler(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Xatolik: {exception.Message}");
        return Task.CompletedTask;
    }
}
