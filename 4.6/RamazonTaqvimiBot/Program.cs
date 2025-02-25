using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace RamazonTaqvimiBot;

internal class Program
{
    private static readonly string botToken = "7983717615:AAFQo2qbpFiUoFbz4vvrRJHsp9_bnk___-Y";
    private static readonly string apiUrl = "https://islomapi.uz/api/daily?region=";
    private static readonly TelegramBotClient botClient = new(botToken);

    static async Task Main()
    {
        botClient.StartReceiving(UpdateHandler, ErrorHandler);
        Console.WriteLine("Bot ishga tushdi...");
        Console.ReadLine();
    }

    private static async Task UpdateHandler(ITelegramBotClient bot, Update update, CancellationToken token)
    {
        var chatId = update.Message?.Chat.Id ?? update.CallbackQuery?.Message?.Chat.Id;
        if (chatId == null) return;

        if (update.Message is { } message)
        {
            if (message.Text == "/start")
            {
                await bot.SendTextMessageAsync(chatId, "Assalomu alaykum! \nRamazon taqvimi botiga xush kelibsiz 😊\n\n", replyMarkup: GetMainButtons());
                await bot.SendTextMessageAsync(chatId, "Qaysi shaharning taqvimi kerak?", replyMarkup: GetRegionButtons());
            }
            else if (message.Text == "Saharlik duosi")
            {
                await bot.SendTextMessageAsync(chatId, "🤲 Saharlik duosi:\n\n" +
                    "اللّهُمَّ إِنِّي لَكَ صُمْتُ وَبِكَ آمَنْتُ وَعَلَيْكَ تَوَكَّلْتُ وَعَلَى رِزْقِكَ أَفْطَرْتُ" +
                    "\n\nNavvaytu an asuma sovma shahri romazona minal fajri ilal mag‘ribi, xolisan lillahi ta’ala. Allohu Akbar!\r\n\n" +
                    "Ma’nosi: Ramazon oyining ro‘zasini subhdan to kun botgunga qadar tutmoqni niyat qildim. Xolis Alloh uchun. Alloh Buyukdir!\r\n\n" +
                    "@Ramazon_Taqvimi_RoBot", replyMarkup: GetMainButtons());
            }
            else if (message.Text == "Iftorlik duosi")
            {
                await bot.SendTextMessageAsync(chatId, "🤲 Iftorlik duosi:\n\n" +
                    "اللّهُمَّ لَكَ صُمْتُ وَبِكَ آمَنْتُ وَعَلَيْكَ تَوَكَّلْتُ وَعَلَى رِزْقِكَ أَفْطَرْتُ" +
                    "\n\nAllohumma laka sumtu va bika amantu va ‘alayka tavakkaltu va ‘ala rizqika aftartu, fag‘firli ya g‘offaruma qoddamtu va ma axxortu. AMIYN!\r\n\n" +
                    "Ma’nosi: Ey Alloh, ushbu ro‘zamni Sen uchun tutdim va Senga iymon keltirdim va Senga tavakkal qildim va bergan rizqing bilan iftor qildim. Ey gunohlarni afv qiluvchi Zot, mening avvalgi va keyingi gunohlarimni mag‘firat qilgin.\r\n\n" +
                    "@Ramazon_Taqvimi_RoBot", replyMarkup: GetMainButtons());
            }
        }
        else if (update.CallbackQuery is { } callback)
        {
            string data = callback.Data!;

            if (IsRegion(data))
            {
                await bot.SendTextMessageAsync(chatId, $"Siz {data} shaharini tanladingiz 😊\n\n1-30 mart orasida sanani tanlang:", replyMarkup: GetDateButtons(data));
            }
            else if (IsDate(data))
            {
                string[] parts = data.Split('|');
                string region = parts[0];
                string date = parts[1];

                string response = await GetPrayerTimes(region, date);
                await bot.SendTextMessageAsync(chatId, $"📅 {date} uchun Ramazon taqvimi :\n{response} \n\n @Ramazon_Taqvimi_RoBot", replyMarkup: GetMainButtons());
            }
            await bot.AnswerCallbackQueryAsync(callback.Id);
        }
    }

    private static Task ErrorHandler(ITelegramBotClient bot, Exception exception, CancellationToken token)
    {
        Console.WriteLine($"Xatolik: {exception.Message}");
        return Task.CompletedTask;
    }


    private static async Task<string> GetPrayerTimes(string region, string date)
    {
        using HttpClient client = new();
        var day = date.Split('-')[0];
        var response = await client.GetStringAsync($"{apiUrl}{region}&month=3&day={day}");
        var json = JObject.Parse(response);
        return $"Saharlik: {json["times"]["tong_saharlik"]} ⏳\nIftorlik: {json["times"]["shom_iftor"]} 🌙";
    }

    private static bool IsRegion(string text)
    {
        string[] regions = { "Toshkent", "Andijon", "Namangan", "Farg'ona", "Samarqand", "Buxoro", "Nukus", "Xiva", "Navoiy", "Qarshi", "Termiz", "Jizzax", "Guliston" };
        return Array.Exists(regions, region => region == text);
    }

    private static bool IsDate(string text)
    {
        return text.Contains("|");
    }

    private static InlineKeyboardMarkup GetRegionButtons()
    {
        return new InlineKeyboardMarkup(new[]
        {
            new[] { InlineKeyboardButton.WithCallbackData("Toshkent", "Toshkent"), InlineKeyboardButton.WithCallbackData("Andijon", "Andijon"), InlineKeyboardButton.WithCallbackData("Namangan", "Namangan") },
            new[] { InlineKeyboardButton.WithCallbackData("Farg'ona", "Farg'ona"), InlineKeyboardButton.WithCallbackData("Samarqand", "Samarqand"), InlineKeyboardButton.WithCallbackData("Buxoro", "Buxoro") },
            new[] { InlineKeyboardButton.WithCallbackData("Xiva", "Xiva"), InlineKeyboardButton.WithCallbackData("Navoiy", "Navoiy"), InlineKeyboardButton.WithCallbackData("Qarshi", "Qarshi") },
            new[] { InlineKeyboardButton.WithCallbackData("Termiz", "Termiz"), InlineKeyboardButton.WithCallbackData("Jizzax", "Jizzax"), InlineKeyboardButton.WithCallbackData("Guliston", "Guliston") },
            new[] { InlineKeyboardButton.WithCallbackData("Nukus", "Nukus")}
        });
    }

    private static InlineKeyboardMarkup GetDateButtons(string region)
    {
        var buttons = new List<InlineKeyboardButton[]>();
        for (int i = 1; i <= 30; i += 5)
        {
            buttons.Add(new InlineKeyboardButton[]
            {
                InlineKeyboardButton.WithCallbackData($"{i}-mart", $"{region}|{i}-mart"),
                InlineKeyboardButton.WithCallbackData($"{i+1}-mart", $"{region}|{i+1}-mart"),
                InlineKeyboardButton.WithCallbackData($"{i+2}-mart", $"{region}|{i+2}-mart"),
                InlineKeyboardButton.WithCallbackData($"{i+3}-mart", $"{region}|{i+3}-mart"),
                InlineKeyboardButton.WithCallbackData($"{i+4}-mart", $"{region}|{i+4}-mart")
            });
        }
        return new InlineKeyboardMarkup(buttons);
    }

    private static ReplyKeyboardMarkup GetMainButtons()
    {
        return new ReplyKeyboardMarkup(new[]
        {
            new KeyboardButton[] { "Saharlik duosi", "Iftorlik duosi" }
        })
        {
            ResizeKeyboard = true
        };
    }
}
