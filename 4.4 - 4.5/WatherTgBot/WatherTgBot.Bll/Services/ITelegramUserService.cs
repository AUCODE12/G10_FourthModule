using WatherTgBot.Bll.DTOs;
using WatherTgBot.Dal.Entities;

namespace WatherTgBot.Bll.Services;

public interface ITelegramUserService
{
    Task<long> AddUser(TelegramUserDto userDto);
    Task<ICollection<TelegramUserDto>> GetAllUsers();

}