using E_CommerceSystem.Dal.Entities;

namespace E_CommerceSystem.Repository.Services;

public interface IUserRepository
{
    Task<long> AddUserAsync(User user);
    Task DeleteUserAsync(long id);
    Task UpdateUserAsync(User updatedUser);
    Task<User> GetUserByIdAsync(long id);
    Task<ICollection<User>> GetAllUsersAsync();
}