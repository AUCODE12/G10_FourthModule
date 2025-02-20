using Microsoft.EntityFrameworkCore;
using WatherTgBot.Dal;
using WatherTgBot.Dal.Entities;

namespace WatherTgBot.Repository.Services;

public class TelegramUserRepository : ITelegramUserRepository
{
    private readonly MainContext? _context;

    public TelegramUserRepository(MainContext? context)
    {
        _context = context;
    }

    public async Task<long> AddUser(TelegramUser user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.BotUserId;
    }

    public async Task<ICollection<TelegramUser>> GetAllUsers()
    {
        return await _context.TelegramUsers.ToListAsync();
    }
}
