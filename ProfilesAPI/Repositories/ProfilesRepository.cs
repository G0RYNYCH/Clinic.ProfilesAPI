using Dapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;

namespace ProfilesAPI.Repositories;

public class ProfilesRepository : IProfilesRepository
{
    private readonly DbContext _dbContext;

    public ProfilesRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Account>> GetAccounts()
    {
        var query = "SELECT * FROM Accounts";
        using (var connection = _dbContext.CreateConnection())
        {
            var accounts = await connection.QueryAsync<Account>(query);
            
            return accounts.ToList();
        }
    }
}