using E_CommerceSystem.Dal.Entities;

namespace E_CommerceSystem.Repository.Services;

public interface IReviewRepository
{
    Task<long> AddReviewAsync(Review review);
    Task DeleteReviewAsync(long id);
    Task UpdateReviewAsync(Review updatedReview);
    Task<Review> GetReviewByIdAsync(long id);
    Task<ICollection<Review>> GetAllReviewsAsync();
}