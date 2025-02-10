using InstagramClone.Dal;
using InstagramClone.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstagramClone.Repository.Services;

public class AccountRepository : IAccountRepository
{
    private readonly MainContext _mainContext;

    public AccountRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<long> AddAccount(Account account)
    {
        await _mainContext.Accounts.AddAsync(account);
        await _mainContext.SaveChangesAsync();
        return account.AccountId;
    }

    public async Task DeleteAccount(long id)
    {
        var account = await GetAccountById(id);
        _mainContext.Remove(account);
        await _mainContext.SaveChangesAsync();
    }

    public async Task<Account> GetAccountById(long id)
    {
        var account = await _mainContext.Accounts.FirstOrDefaultAsync(a => a.AccountId == id);
        if (account is null) throw new Exception("Not Found");
        return account;
    }

    public async Task<List<Account>> GetAllAccounts()
    {
        return await _mainContext.Accounts.ToListAsync();
    }

    public async Task UpdateAccount(Account account)
    {
        var accountFind = await GetAccountById(account.AccountId);

        accountFind.Username = account.Username;
        accountFind.Posts = account.Posts;
        accountFind.Bio = account.Bio;
        accountFind.Folleowers = account.Folleowers;
        accountFind.Following = account.Following;
        
        await _mainContext.SaveChangesAsync();
    }
}
