using Dapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;

namespace ProfilesAPI.Repositories;

public class AccountsRepository : IAccountsRepository
{
    private readonly DbContext _dbContext;

    public AccountsRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Account>> GetAccountsAsync()
    {
        var query = "SELECT * FROM Accounts";
        using (var connection = _dbContext.CreateConnection())
        {
            var accounts = await connection.QueryAsync<Account>(query);
            
            return accounts.ToList();
        }
    }

    public async Task<Account> GetAccountByIdAsync(Guid id)
    {
        var query = "SELECT * FROM Accounts WHERE Id = @Id";
        using (var connection = _dbContext.CreateConnection())
        {
            var account = await connection.QuerySingleOrDefaultAsync<Account>(query, new {id});
            
            return account;
        }
    }
}