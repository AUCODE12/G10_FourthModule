using E_CommerceSystem.Dal.Entities;

namespace E_CommerceSystem.Repository.Services;

public interface IProductRepository
{
    Task<long> AddProductAsync(Product product);
    Task DeleteProductAsync(long id);
    Task UpdateProductAsync(Product updatedProduct);
    Task<Product> GetProductByIdAsync(long id);
    Task<ICollection<Product>> GetAllProductsAsync();
}