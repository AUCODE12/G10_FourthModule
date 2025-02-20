using E_CommerceSystem.Dal.Entities;

namespace E_CommerceSystem.Repository.Services;

public interface ICategoryRepository
{
    Task<long> AddCategoryAsync(Category category);
    Task DeleteCategoryAsync(long id);
    Task UpdateCategoryAsync(Category updatedCategory);
    Task<Category> GetCategoryByIdAsync(long id);
    Task<ICollection<Category>> GetAllCategorysAsync();
}