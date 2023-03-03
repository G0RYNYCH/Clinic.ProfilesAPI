using ProfilesAPI.Models;

namespace ProfilesAPI.Interfaces;

public interface IProfilesRepository
{
    public Task<IEnumerable<Account>> GetAccounts();
}