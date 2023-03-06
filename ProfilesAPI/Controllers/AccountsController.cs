using Microsoft.AspNetCore.Mvc;
using ProfilesAPI.Interfaces;

namespace ProfilesAPI.Controllers;

[ApiController]
[Route("api/profiles")]
public class AccountsController : ControllerBase
{
    private readonly IAccountsRepository _accountsRepository;

    public AccountsController(IAccountsRepository accountsRepository)
    {
        _accountsRepository = accountsRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAccounts()
    {
        try
        {
            var accounts = await _accountsRepository.GetAccountsAsync();

            return Ok(accounts);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccount([FromRoute]Guid id)
    {
        try
        {
            var account = await _accountsRepository.GetAccountByIdAsync(id);
            if (account == null)
                return NotFound();

            return Ok(account);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }
}