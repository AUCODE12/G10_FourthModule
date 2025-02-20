using WatherTgBot.Dal.Entities;

namespace WatherTgBot.Repository.Services;

public interface ITelegramUserRepository
{
    Task<long> AddUser(TelegramUser user);
    Task<ICollection<TelegramUser>> GetAllUsers();
}