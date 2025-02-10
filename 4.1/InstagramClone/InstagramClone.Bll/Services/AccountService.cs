using InstagramClone.Bll.DTOs;
using InstagramClone.Dal.Entities;
using InstagramClone.Repository.Services;

namespace InstagramClone.Bll.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<long> AddAccount(AccountDto account)
    {
        return await _accountRepository.AddAccount(ConvertToAccountEntity(account));
    }

    public async Task DeleteAccount(long id)
    {
        await _accountRepository.DeleteAccount(id);
    }

    public async Task<AccountDto> GetAccountById(long id)
    {
        return ConvertToDto(await _accountRepository.GetAccountById(id));
    }

    public async Task<List<AccountDto>> GetAllAccounts()
    {
        var accounts = await _accountRepository.GetAllAccounts();
        return accounts.Select(a => ConvertToDto(a)).ToList();
    }

    public async Task UpdateAccount(AccountDto account)
    {
        await _accountRepository.UpdateAccount(ConvertToAccountEntity(account));
    }

    private Account ConvertToAccountEntity(AccountDto accountDto)
    {
        return new Account
        {
            Bio = accountDto.Bio,
            Username = accountDto.Username,
        };
    }

    private AccountDto ConvertToDto(Account account)
    {
        return new AccountDto
        {
            Bio = account.Bio,
            Username = account.Username,
        };
    }
}
