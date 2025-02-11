using InstagramClone.Bll.DTOs;
using InstagramClone.Bll.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.Server.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("register")]
    public async Task<long> PostAccount(AccountCreateDto account)
    {
        return await _accountService.AddAccount(account);
    }

    [HttpPut("edit")]
    public async Task PutAccount(AccountCreateDto account)
    {
        await _accountService.UpdateAccount(account);
    }

    [HttpDelete("delete/{id}")]
    public async Task DeleteAccount(long id)
    {
        await _accountService.DeleteAccount(id);
    }

    [HttpGet("get/{id}")]
    public async Task<AccountDto> GetAccountById(long id)
    {
        return await _accountService.GetAccountById(id);
    }

    [HttpGet("getAll")]
    public async Task<List<AccountDto>> GetAllAccounts()
    {
        return await _accountService.GetAllAccounts();
    }
}
