using E_CommerceSystem.Dal.Entities;
using E_CommerceSystem.Dal;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceSystem.Repository.Services;

public class CartRepository : ICartRepository
{
    private readonly MainContext _mainContext;

    public CartRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<long> AddCartAsync(Cart cart)
    {
        await _mainContext.Carts.AddAsync(cart);
        await _mainContext.SaveChangesAsync();
        return cart.UserId;
    }

    public async Task DeleteCartAsync(long id)
    {
        var cart = await GetCartByIdAsync(id);
        _mainContext.Remove(cart);
        await _mainContext.SaveChangesAsync();
    }

    public async Task<ICollection<Cart>> GetAllCartsAsync()
    {
        return await _mainContext.Carts.ToListAsync();
    }

    public async Task<Cart> GetCartByIdAsync(long id)
    {
        var cart = await _mainContext.Carts.FirstOrDefaultAsync(u => u.CartId == id);
        if (cart is null) throw new Exception("Not Found");
        return cart;
    }

    public async Task UpdateCartAsync(Cart updatedCart)
    {
        _mainContext.Carts.Update(updatedCart);
        await _mainContext.SaveChangesAsync();
    }
}
