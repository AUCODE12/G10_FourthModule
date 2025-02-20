using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using WatherTgBot.Bll.DTOs;
using WatherTgBot.Dal.Entities;
using WatherTgBot.Repository.Services;

namespace WatherTgBot.Bll.Services;

public class TelegramUserService : ITelegramUserService
{
    private readonly ITelegramUserRepository? _telegramUserRepository;

    public TelegramUserService(ITelegramUserRepository? telegramUserRepository)
    {
        _telegramUserRepository = telegramUserRepository;
    }
    public async Task<long> AddUser(TelegramUserDto userDto)
    {
        return await _telegramUserRepository.AddUser(ConvertToTelegramUserEntity(userDto));
    }


    public async Task<ICollection<TelegramUserDto>> GetAllUsers()
    {
        var users = await _telegramUserRepository.GetAllUsers();
        return users.Select(u => ConvertToDto(u)).ToList();
    }

    private TelegramUser ConvertToTelegramUserEntity(TelegramUserDto userDto)
    {
        return new TelegramUser
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Username = userDto.Username,
            IsBlocked = userDto.IsBlocked,
            PhoneNumber = userDto.PhoneNumber,
            CreatedAt = DateTime.Now,
            TelegramUserId = userDto.TelegramUserId,
            UpdatedAt = userDto.UpdatedAt
        };
    }

    private TelegramUserDto ConvertToDto(TelegramUser user)
    {
        return new TelegramUserDto
        {
            TelegramUserId = user.TelegramUserId,
            UpdatedAt = user.UpdatedAt,
            Username = user.Username,
            CreatedAt = user.CreatedAt,
            FirstName = user.FirstName,
            IsBlocked = user.IsBlocked,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber
        };
    }
    
}
