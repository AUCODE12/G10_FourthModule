using E_CommerceSystem.Dal.Entities;

namespace E_CommerceSystem.Repository.Services;

public interface IPaymentRepository
{
    Task<long> AddPaymentAsync(Payment payment);
    Task DeletePaymentAsync(long id);
    Task UpdatePaymentAsync(Payment updatedPayment);
    Task<Payment> GetPaymentByIdAsync(long id);
    Task<ICollection<Payment>> GetAllPaymentsAsync();
}