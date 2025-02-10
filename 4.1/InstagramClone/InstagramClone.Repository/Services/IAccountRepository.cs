using InstagramClone.Dal.Entities;

namespace InstagramClone.Repository.Services;

public interface IAccountRepository
{
    Task<long> AddAccount(Account account);
    
    Task UpdateAccount(Account account);

    Task DeleteAccount(long id);

    Task<Account> GetAccountById(long id);

    Task<List<Account>> GetAllAccounts();
}