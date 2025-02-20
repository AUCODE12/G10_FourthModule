using E_CommerceSystem.Dal.Entities;

namespace E_CommerceSystem.Repository.Services;

public interface IOrderRepository
{
    Task<long> AddOrderAsync(Order order);
    Task DeleteOrderAsync(long id);
    Task UpdateOrderAsync(Order updatedOrder);
    Task<Order> GetOrderByIdAsync(long id);
    Task<ICollection<Order>> GetAllOrdersAsync();
}