using ProfilesAPI.Models;

namespace ProfilesAPI.Interfaces;

public interface IAccountsRepository
{
    public Task<IEnumerable<Account>> GetAccountsAsync();
    public Task<Account> GetAccountByIdAsync(Guid id);
}