using E_CommerceSystem.Dal.Entities;

namespace E_CommerceSystem.Repository.Services;

public interface ICartRepository
{
    Task<long> AddCartAsync(Cart cart);
    Task DeleteCartAsync(long id);
    Task UpdateCartAsync(Cart updatedCart);
    Task<Cart> GetCartByIdAsync(long id);
    Task<ICollection<Cart>> GetAllCartsAsync();
}