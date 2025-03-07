using ChatBot.Bll.Services;
using ChatBot.Dal.Entites;
using System.Globalization;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace G10TestChatBot;

public class BotListenerService
{
    private static string botToken = "8144693012:AAFAIaFdB7tngMYge3bCrU81QjPp_vE7OP4";
    private TelegramBotClient botClient = new TelegramBotClient(botToken);
    private readonly IBotUserService botUserService;
    private readonly IUserInfoService userInfoService;
    private readonly IEducationService educationService;
    private readonly ISkillService skillService;
    private readonly IExperienceService experienceService;
    private readonly IFileService fileService;

    public BotListenerService(IBotUserService userService, IUserInfoService userInfoService, IEducationService educationService, ISkillService skillService, IExperienceService experienceService, IFileService fileService)
    {
        this.botUserService = userService;
        this.userInfoService = userInfoService;
        this.educationService = educationService;
        this.skillService = skillService;
        this.experienceService = experienceService;
        this.fileService = fileService;
    }

    public async Task StartBot()
    {
        botClient.StartReceiving(
            HandleUpdateAsync,
            HandleErrorAsync
            );

        Console.WriteLine("Bot is runing");

        Console.ReadKey();
    }

    private async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
    {
        if (update.Type == UpdateType.Message)
        {
            var user = update.Message.Chat;
            var message = update.Message;
            var botUserId = await botUserService.GetBotUserIdByTelegramUserIdAsync(user.Id);
            var userInfoId = await userInfoService.GetUserInfoIdByBotUserIdAsync(botUserId);

            if (message.Text == "/start")
            {
                var savingUser = new BotUser()
                {
                    TelegramUserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    UpdatedAt = DateTime.UtcNow,
                };

                await botUserService.AddUserAsync(savingUser);

                await SendStartMenu(bot, user.Id);
                return;
            }

            if (message.Text == "Main menu")
            {
                var menu = new ReplyKeyboardMarkup(new[]
                {
                    new[]
                    {
                        new KeyboardButton("User Info"),
                        new KeyboardButton("Education"),
                        new KeyboardButton("Experience")
                    },
                    new[]
                    {
                        new KeyboardButton("Skills"),
                        new KeyboardButton("Get CV in .pdf"),
                        new KeyboardButton("Get CV in .word")
                    }
                })
                {
                    ResizeKeyboard = true
                };

                await botClient.SendTextMessageAsync(
                    chatId: user.Id,
                    text: "You get main menu",
                    parseMode: ParseMode.Markdown,
                    replyMarkup: menu
                );

                return;
            }

            if (message.Text == "User Info")
            {
                var userInfo = await userInfoService.GetUserInfoByBotUserIdAsync(botUserId);

                var menu = new ReplyKeyboardMarkup()
                {
                    ResizeKeyboard = true
                };

                var textOfUserInfo = "";

                if (userInfo == null)
                {
                    textOfUserInfo = "Your info not found press\nCreate user info button to create";

                    menu.AddButtons(
                        new KeyboardButton("Create user info"),
                        new KeyboardButton("Main menu"));
                }
                else
                {
                    textOfUserInfo = $"Your personal info below\n" +
                                     $"UserId      : {userInfo.UserInfoId}\n" +
                                     $"Firstname   : {userInfo.FirstName}\n" +
                                     $"Lastname    : {userInfo.LastName}\n" +
                                     $"Phonenumber : {userInfo.PhoneNumber}\n" +
                                     $"Email       : {userInfo.Email}\n" +
                                     $"Address     : {userInfo.Address}\n" +
                                     $"Summary     : {userInfo.Summary}\n";

                    menu.AddButtons(
                        new KeyboardButton("Delete all user info"),
                        new KeyboardButton("Main menu"));
                }

                await bot.SendTextMessageAsync(
                chatId: user.Id,
                text: textOfUserInfo,
                parseMode: ParseMode.Markdown,
                replyMarkup: menu
                );

                return;
            }

            if (message.Text == "Create user info")
            {
                var userInfoText = "Please enter your details in the following format:\n\n" +
                      "*First Name*\n" +
                      "*Last Name*\n" +
                      "*Email*\n" +
                      "*Phone Number*\n" +
                      "*Address*\n" +
                      "*Summary*\n\n" +
                      "Example:\n\n" +
                      "Create user info\n John\n Doe\n john.doe@example.com\n +1234567890\n 123 Main St, City, Country\n I am .net developer";

                await bot.SendTextMessageAsync(
                chatId: user.Id,
                text: userInfoText,
                parseMode: ParseMode.Markdown
                );

                return;
            }

            if (message.Text == "Delete all user info")
            {
                await bot.SendTextMessageAsync(
                    chatId: user.Id,
                    text: "Delete user info enter like this format\n\nDelete",
                    parseMode: ParseMode.Markdown
                );

                return;
            }

            if (message.Text.StartsWith("Delete"))
            {
                //var deletionId = long.Parse(message.Text.Substring(20).Trim());

                await userInfoService.DeleteUserInfoAsync(1);

                await bot.SendTextMessageAsync(
                chatId: user.Id,
                text: "User Info is deleted",
                parseMode: ParseMode.Markdown
                );

                return;
            }

            if (message.Text.StartsWith("Create user info"))
            {
                var userInfotext = message.Text;
                var data = userInfotext.Split("\n");
                var userInfo = new UserInfo()
                {
                    FirstName = data[1].Trim(),
                    LastName = data[2].Trim(),
                    Email = data[3].Trim(),
                    PhoneNumber = data[4].Trim(),
                    Address = data[5].Trim(),
                    BotUserId = botUserId
                };

                for (var i = 6; i < data.Count(); i++)
                {
                    userInfo.Summary += data[i].Trim() + " ";
                }

                var resFromAddUserInfoAsync = await userInfoService.AddUserInfoAsync(userInfo);

                var textToBotUser = "";

                if (resFromAddUserInfoAsync == 0)
                {
                    textToBotUser = "Error occuried while saving";
                }
                else
                {
                    textToBotUser = "Successfully saved";
                }

                await bot.SendTextMessageAsync(
                chatId: user.Id,
                text: textToBotUser,
                parseMode: ParseMode.Markdown
                );

                await SendStartMenu(bot, user.Id);
            }

            if (message.Text == "Education")
            {
                var userInfo = await userInfoService.GetUserInfoByBotUserIdAsync(botUserId);
                var menuNullUser = new ReplyKeyboardMarkup()
                {
                    ResizeKeyboard = true
                };

                var textOfUserInfo = "";
                if (userInfo is null)
                {
                    textOfUserInfo = "Your info not found press\nCreate user info button to create";

                    menuNullUser.AddButtons(
                        new KeyboardButton("Create user info"),
                        new KeyboardButton("Main menu"));

                    await bot.SendTextMessageAsync(
                    chatId: user.Id,
                    text: textOfUserInfo,
                    parseMode: ParseMode.Markdown,
                    replyMarkup: menuNullUser
                    );
                }
                else
                {
                    var educations = await educationService.GetEducationsByUserInfoIdAsync(userInfoId);

                    var educationText = "Your education info below \n\n";

                    foreach (var education in educations)
                    {
                        educationText += $"EducationId : {education.EducationId}\n" +
                                         $"Institution : {education.Institution}\n\n";
                    }

                    var menu = new ReplyKeyboardMarkup(
                            new KeyboardButton("Add education"),
                            new KeyboardButton("Delete education"),
                            new KeyboardButton("Main menu"))
                    {
                        ResizeKeyboard = true
                    };

                    await botClient.SendTextMessageAsync(
                    chatId: user.Id,
                    text: educationText,
                    parseMode: ParseMode.Html,
                    replyMarkup: menu);
                }
                return;

            }

            if (message.Text == "Add education")
            {
                var userInfoText = "Please enter education details in the following format:\n\n" +
                      "*Institution*\n" +
                      "*Degree*\n" +
                      "*StartDate*\n" +
                      "*EndDate*\n\n" +

                      "Example:\n" +
                      "Add education:\n" +
                      "TSIOS\n" +
                      "Bachalor\n" +
                      "2021-09-01\n" +
                      "2024-09-01\n";

                await bot.SendTextMessageAsync(
                chatId: user.Id,
                text: userInfoText,
                parseMode: ParseMode.Markdown
                );

                return;
            }

            if (message.Text == "Delete education")
            {
                await bot.SendTextMessageAsync(
                chatId: user.Id,
                text: "Enter education id like this format\n Delete educationId : place id",
                parseMode: ParseMode.Markdown
                );

                return;
            }

            if (message.Text.StartsWith("Delete educationId : "))
            {
                var deletionId = long.Parse(message.Text.Substring(21).Trim());

                await educationService.DeleteEducationAsync(deletionId, userInfoId);

                await bot.SendTextMessageAsync(
                chatId: user.Id,
                text: "Education is deleted",
                parseMode: ParseMode.Markdown
                );

                return;
            }

            if (message.Text.StartsWith("Add education"))
            {
                var educationInfotext = message.Text;
                var data = educationInfotext.Split("\n");
                var education = new Education()
                {
                    Institution = data[1],
                    Degree = data[2],
                    StartDate = DateTime.ParseExact(data[3], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact(data[4], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    UserInfoId = userInfoId
                };

                await educationService.AddEducationAsync(education);


                await bot.SendTextMessageAsync(
                chatId: user.Id,
                text: "Saved",
                parseMode: ParseMode.Markdown
                );
            }

            if (message.Text == "Experience")
            {
                var userInfo = await userInfoService.GetUserInfoByBotUserIdAsync(botUserId);
                var menuNullUser = new ReplyKeyboardMarkup()
                {
                    ResizeKeyboard = true
                };

                var textOfUserInfo = "";
                if (userInfo is null)
                {
                    textOfUserInfo = "Your info not found press\nCreate user info button to create";

                    menuNullUser.AddButtons(
                        new KeyboardButton("Create user info"),
                        new KeyboardButton("Main menu"));

                    await bot.SendTextMessageAsync(
                        chatId: user.Id,
                        text: textOfUserInfo,
                        parseMode: ParseMode.Markdown,
                        replyMarkup: menuNullUser
                        );
                }
                else
                {
                    var experiences = await experienceService.GetExperiencesByUserInfoIdAsync(userInfoId);
                    var experienceText = "Your experience below \n\n";
                    foreach (var item in experiences)
                    {
                        experienceText += $"ExperienceId: {item.ExperienceId}\n" +
                            $"Company: {item.Company}\n" +
                            $"Position: {item.Position}" +
                            $"StartDate: {item.StartDate}\n" +
                            $"EndDate: {item.EndDate}\n" +
                            $"Description: {item.Description}";
                    }
                    var menu = new ReplyKeyboardMarkup(
                        new KeyboardButton("Add experience"),
                        new KeyboardButton("Delete experience"),
                        new KeyboardButton("Main menu"))
                    {
                        ResizeKeyboard = true
                    };

                    await botClient.SendTextMessageAsync(
                        chatId: user.Id,
                        text: experienceText,
                        parseMode: ParseMode.Markdown,
                        replyMarkup: menu);
                }

                return;
            }

            if (message.Text == "Add experience")
            {
                var userInfoText = "Please enter experience details in the following format:\n\n" +
                      "*Company*\n" +
                      "*Position*\n" +
                      "*StartDate*\n" +
                      "*EndDate*\n" +
                      "*Description*\n" +

                      "Example:\n" +
                      "Add experience\n" +
                      "Epam\n" +
                      "Junior\n" +
                      $"{DateTime.UtcNow}\n" +
                      $"{DateTime.UtcNow}\n" +
                      "Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque dis parturient montes, nascetur ridiculus mus.\n";

                await bot.SendTextMessageAsync(
                chatId: user.Id,
                text: userInfoText,
                parseMode: ParseMode.Markdown
                );

                return;
            }

            if (message.Text == "Delete experience")
            {
                await bot.SendTextMessageAsync(
                    chatId: user.Id,
                    text: "Enter experience id like this format\n Delete experienceId : place id",
                    parseMode: ParseMode.Markdown
                );

                return;
            }

            if (message.Text.StartsWith("Add experience"))
            {
                var experienceInfotext = message.Text;
                var data = experienceInfotext.Split("\n");
                var experience = new Experience()
                {
                    Company = data[1],
                    Position = data[2],
                    StartDate = DateTime.ParseExact(data[3], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact(data[4], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Description = data[5],
                    UserInfoId = userInfoId
                };

                await experienceService.AddExperienceAsync(experience);


                await bot.SendTextMessageAsync(
                chatId: user.Id,
                text: "Saved",
                parseMode: ParseMode.Markdown
                );
            }

            if (message.Text.StartsWith("Delete experienceId : "))
            {
                var deletionId = long.Parse(message.Text.Substring(21).Trim());

                await experienceService.DeleteExperienceAsync(deletionId, userInfoId);

                await bot.SendTextMessageAsync(
                chatId: user.Id,
                text: "Experience is deleted",
                parseMode: ParseMode.Markdown
                );

                return;
            }

            if (message.Text == "Skills")
            {
                var userInfo = await userInfoService.GetUserInfoByBotUserIdAsync(botUserId);
                var menuNullUser = new ReplyKeyboardMarkup()
                {
                    ResizeKeyboard = true
                };

                var textOfUserInfo = "";
                if (userInfo == null)
                {
                    textOfUserInfo = "Your info not found press\nCreate user info button to create";

                    menuNullUser.AddButtons(
                        new KeyboardButton("Create user info"),
                        new KeyboardButton("Main menu"));

                    await bot.SendTextMessageAsync(
                        chatId: user.Id,
                        text: textOfUserInfo,
                        parseMode: ParseMode.Markdown,
                        replyMarkup: menuNullUser
                        );

                }
                else
                {
                    var skills = await skillService.GetSkillsByUserInfoIdAsync(userInfoId);
                    var skillText = "Your skill info below \n\n";

                    foreach (var skill in skills)
                    {
                        skillText += $"SkillId : {skill.SkillId}\n" +
                                         $"Name : {skill.Name}\n" +
                                         $"ProficiencyLevel : {skill.ProficiencyLevel}\n";
                    }

                    var menu = new ReplyKeyboardMarkup(
                            new KeyboardButton("Add skill"),
                            new KeyboardButton("Delete skill"),
                            new KeyboardButton("Main menu"))
                    {
                        ResizeKeyboard = true
                    };

                    await botClient.SendTextMessageAsync(
                    chatId: user.Id,
                    text: skillText,
                    parseMode: ParseMode.Html,
                    replyMarkup: menu);
                }
                return;
            }

            if (message.Text == "Add skill")
            {
                var userInfoText = "Please enter skill details in the following format:\n\n" +
                      "*Name*\n" +
                      "*ProficiencyLevel*\n" +

                      "Example:\n" +
                      "Add skill:\n" +
                      "ASP.NET Core\n";

                await bot.SendTextMessageAsync(
                chatId: user.Id,
                text: userInfoText,
                parseMode: ParseMode.Markdown
                );

                return;
            }

            if (message.Text == "Delete skill")
            {
                await bot.SendTextMessageAsync(
                chatId: user.Id,
                text: "Enter skill id like this format\n Delete skillId : place id",
                parseMode: ParseMode.Markdown
                );

                return;
            }

            if (message.Text.StartsWith("Delete skillId : "))
            {
                var deletionId = long.Parse(message.Text.Substring(17).Trim());

                await skillService.DeleteSkillAsync(deletionId, userInfoId);

                await bot.SendTextMessageAsync(
                chatId: user.Id,
                text: "Skill is deleted",
                parseMode: ParseMode.Markdown
                );

                return;
            }

            if (message.Text.StartsWith("Add skill"))
            {
                var skillInfotext = message.Text;
                var data = skillInfotext.Split("\n");

                var skill = new Skill()
                {
                    Name = data[1],
                    ProficiencyLevel = data[2],
                    UserInfoId = userInfoId
                };

                await skillService.AddSkillAsync(skill);


                await bot.SendTextMessageAsync(
                chatId: user.Id,
                text: "Saved",
                parseMode: ParseMode.Markdown
                );
            }

            if (message.Text == "Get CV in .pdf")
            {
                var pdfBytes = await fileService.GenerateCVAsync(botUserId);

                using (var stream = new MemoryStream(pdfBytes))
                {
                    await botClient.SendDocumentAsync(
                        chatId: message.Chat.Id,
                        document: new InputFileStream(stream, "CV.pdf"),
                        caption: "Here is your CV in PDF format."
                    );
                }

                return;
            }

            if (message.Text == "Get CV in .word")
            {
                return;
            }
        }

        else if (update.Type == UpdateType.CallbackQuery)
        {
            var id1 = update.CallbackQuery.Id;
            var id2 = update.CallbackQuery.InlineMessageId;
            var id = update.CallbackQuery.From.Id;

            CallbackQuery res = update.CallbackQuery;

            var rep = update.CallbackQuery.Data;


            await bot.SendTextMessageAsync(id, $"your option : {update.CallbackQuery.Data}");
        }
    }

    private async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine(exception.Message);
    }

    private static async Task SendUserInfoMenu(ITelegramBotClient botClient, long userId)
    {
        var menu = new ReplyKeyboardMarkup(
            new KeyboardButton("Fill user info"),
            new KeyboardButton("Update user info"),
            new KeyboardButton("Delete user info"))
        {
            ResizeKeyboard = true
        };


    }

    private static async Task SendStartMenu(ITelegramBotClient botClient, long userId)
    {
        var menu = new ReplyKeyboardMarkup(new[]
        {
            new[]
            {
                new KeyboardButton("User Info"),
                new KeyboardButton("Education"),
                new KeyboardButton("Experience")
            },
            new[]
            {
                new KeyboardButton("Skills"),
                new KeyboardButton("Get CV in .pdf"),
                new KeyboardButton("Get CV in .word")
            }
        })
        {
            ResizeKeyboard = true
        };



        var introText = @"
            🌟 *Welcome to the CV Builder Bot!* 🌟

            I'm here to help you create a **professional CV in PDF format** effortlessly. Here's how it works:

            1. **Provide Your Information**: Fill in your personal details, work experience, education, and skills.
            2. **Review and Confirm**: You can review and edit your information at any time.
            3. **Generate Your CV**: Once everything is ready, I'll create a polished PDF version of your CV for you to download.

            📝 *What you'll need to provide:*
            - **User Info**: Name, contact details, etc.
            - **Education**: Your academic background and qualifications.
            - **Experience**: Your past jobs, roles, and achievements.
            - **Skills**: Your key skills and expertise.

            🚀 *Ready to get started?*
            Use the buttons below to fill in your details or generate your CV!

            Need help? Just type /help at any time.

            Let's create an amazing CV together! 😊
            ";

        await botClient.SendTextMessageAsync(
            chatId: userId,
            text: introText,
            parseMode: ParseMode.Markdown,
            replyMarkup: menu
        );
    }
}
