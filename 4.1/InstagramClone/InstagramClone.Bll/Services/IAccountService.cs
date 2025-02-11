using InstagramClone.Bll.DTOs;

namespace InstagramClone.Bll.Services;

public interface IAccountService
{
    Task<long> AddAccount(AccountCreateDto account);

    Task UpdateAccount(AccountCreateDto account);

    Task DeleteAccount(long id);

    Task<AccountDto> GetAccountById(long id);

    Task<List<AccountDto>> GetAllAccounts();
}