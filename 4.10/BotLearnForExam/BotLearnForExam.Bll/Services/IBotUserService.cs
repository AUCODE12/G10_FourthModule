using BotLearnForExam.Dal.Entities;

namespace BotLearnForExam.Bll.Services;

public interface IBotUserService
{
    Task<long> AddBotUserAsync(BotUser botUser);
}