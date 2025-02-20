using E_CommerceSystem.Dal.Entities;

namespace E_CommerceSystem.Repository.Services;

public interface IOrderProductRepository
{
    Task<long> AddOrderProductAsync(OrderProduct order);
    Task DeleteOrderProductAsync(long id);
    Task UpdateOrderProductAsync(OrderProduct updatedOrderProduct);
    Task<OrderProduct> GetOrderProductByIdAsync(long id);
    Task<ICollection<OrderProduct>> GetAllOrderProductsAsync();
}