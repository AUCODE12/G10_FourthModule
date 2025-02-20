using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Wather7Tg.BotConfiguration;
using Wather7Tg.BotConfiguration.Entities;

namespace TelegramBotWithSQL
{
    class Program
    {
        private static readonly string Token = "8155349093:AAHT_1xd4X5Rlmx4MP8ut6oVRWUADSGYOx0";
        private static readonly TelegramBotClient Bot = new(Token);

        static async Task Main()
        {
            using var cts = new CancellationTokenSource();
            var receiverOptions = new ReceiverOptions { AllowedUpdates = { } };

            Bot.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, cts.Token);

            Console.WriteLine("Bot ishga tushdi...");
            Console.ReadLine();
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
            using var db = new MainContext();
            var existingUser = db.Users.FirstOrDefault(u => u.TelegramUserId == message.Chat.Id);

            if (existingUser == null)
            {
                var newUser = new TelegramUser
                {
                    TelegramUserId = message.Chat.Id,
                    FirstName = message.Chat.FirstName,
                    LastName = message.Chat.LastName,
                    Username = message.Chat.Username
                };

                db.Users.Add(newUser);
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
}
