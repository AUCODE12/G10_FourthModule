using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Bot1;

internal class Program
{
    private static string token = "8144693012:AAFAIaFdB7tngMYge3bCrU81QjPp_vE7OP4";
    private static TelegramBotClient client = null;

    static async Task Main()
    {
        Console.WriteLine("Dastur ishga tushdi");

        client = new TelegramBotClient(token);
        client.OnMessage += Client_OnMessage;
        client.StartReceiving(); 
        Console.WriteLine("Dasturdan chiqish uchun Enterni bosing");
        Console.ReadLine();
    }

    private static Task Client_OnMessage(Message message, UpdateType type)
    {
        Console.WriteLine($"Botdan kelgan xabar: {message.Text}");
    }
}



//Bot.StartReceiving(HandleUpdateAsync, HandleErrorAsync);

//Console.WriteLine("Bot ishga tushdi...");
//Console.ReadLine();

//private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
//{
//    if (update.Type != UpdateType.Message || update.Message!.Type != MessageType.Text)
//        return;

//    var message = update.Message;
//    var chatId = message.Chat.Id;

//    if (message.Text == "/start")
//    {
//        await RegisterUser(message);
//        await botClient.SendTextMessageAsync(chatId, "Assalomu alaykum! Ushbu bot haqida ma’lumot:\n\nBu bot sizning ma’lumotlaringizni bazaga saqlaydi va sizga xizmat ko‘rsatadi.");
//    }
//}

//private static async Task RegisterUser(Message message)
//{
//    using var db = new MainContext();
//    var existingUser = db.Users.FirstOrDefault(u => u.BotUserId == message.Chat.Id);

//    if (existingUser == null)
//    {
//        var newUser = new TelegramUser
//        {
//            BotUserId = message.Chat.Id,
//            FirstName = message.Chat.FirstName,
//            LastName = message.Chat.LastName,
//            Username = message.Chat.Username
//        };

//        db.Users.Add(newUser);
//        await db.SaveChangesAsync();
//        Console.WriteLine($"Yangi foydalanuvchi qo‘shildi: {newUser.FirstName} ({newUser.BotUserId})");
//    }
//    else
//    {
//        Console.WriteLine($"Foydalanuvchi allaqachon mavjud: {existingUser.FirstName} ({existingUser.BotUserId})");
//    }

//}

//private static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
//{

//}