using BotLearnForExam.Dal;
using BotLearnForExam.Dal.Entities;

namespace BotLearnForExam.Bll.Services;

public class BotUserService : IBotUserService
{
    private readonly MainContext mainContext;

    public BotUserService(MainContext mainContext)
    {
        this.mainContext = mainContext;
    }

    public async Task<long> AddBotUserAsync(BotUser botUser)
    {
        await mainContext.botUsers.AddAsync(botUser);
        await mainContext.SaveChangesAsync();
        return botUser.BotUserId;
    }
}
