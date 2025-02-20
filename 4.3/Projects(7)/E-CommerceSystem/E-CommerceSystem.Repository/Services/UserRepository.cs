using E_CommerceSystem.Dal;
using E_CommerceSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceSystem.Repository.Services;

public class UserRepository : IUserRepository
{
    private readonly MainContext _mainContext;

    public UserRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<long> AddUserAsync(User user)
    {
        await _mainContext.Users.AddAsync(user);
        await _mainContext.SaveChangesAsync();
        return user.UserId;
    }

    public async Task DeleteUserAsync(long id)
    {
        var user = await GetUserByIdAsync(id);
        _mainContext.Remove(user);
        await _mainContext.SaveChangesAsync();
    }

    public async Task<ICollection<User>> GetAllUsersAsync()
    {
        return await _mainContext.Users.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(long id)
    {
        var user = await _mainContext.Users.FirstOrDefaultAsync(u => u.UserId == id);
        if (user is null) throw new Exception("Not Found");
        return user;
    }

    public async Task UpdateUserAsync(User updatedUser)
    {
        _mainContext.Users.Update(updatedUser);
        await _mainContext.SaveChangesAsync();
    }
}
