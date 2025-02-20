using E_CommerceSystem.Dal.Entities;

namespace E_CommerceSystem.Repository.Services;

public interface ICardProductRepository
{
    Task<long> AddCartProductAsync(CartProduct cartProduct);
    Task DeleteCartProductAsync(long id);
    Task UpdateCartProductAsync(CartProduct updatedCartProduct);
    Task<CartProduct> GetCartProductByIdAsync(long id);
    Task<ICollection<CartProduct>> GetAllCartProductsAsync();
}