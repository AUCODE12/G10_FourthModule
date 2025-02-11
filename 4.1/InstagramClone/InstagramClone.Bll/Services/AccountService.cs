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

    public async Task<long> AddAccount(AccountCreateDto account)
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

    public async Task UpdateAccount(AccountCreateDto account)
    {
        await _accountRepository.UpdateAccount(ConvertToAccountEntity(account));
    }

    private Account ConvertToAccountEntity(AccountCreateDto accountCreateDto)
    {
        return new Account
        {
            AccountId = accountCreateDto.AccountId ?? 0,
            Bio = accountCreateDto.Bio,
            Username = accountCreateDto.Username,
        };
    }

    private AccountDto ConvertToDto(Account account)
    {
        return new AccountDto
        {
            Bio = account.Bio,
            Username = account.Username,
            AccountId = account.AccountId,
            Comments = account.Comments?.Select(c => new CommentDto
            {
                CommentId = c.CommentId,
                ContentText = c.ContentText,
                WritingTime = c.WritingTime,
                AccountId = c.AccountId,
                PostId = c.PostId,
                ReplyToCommentId = c.ReplyToCommentId,
            }).ToList(),
            Folleowers = account.Folleowers?.Select(fo => new AccountDto
            {
                AccountId = fo.AccountId,
                Bio = fo.Bio,
                Username = fo.Username,
            }).ToList(),
            Following = account.Following?.Select(f => new AccountDto
            {
                AccountId = f.AccountId,
                Bio = f.Bio,
                Username = f.Username,
            }).ToList(),
            Posts = account.Posts?.Select(p => new PostDto
            {
                PostId = p.PostId,
                AccountId = p.AccountId,
                PostType = p.PostType,
                SetTime = p.SetTime,
            }).ToList(),    
        };
    }
}
