using Dapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;

namespace ProfilesAPI.Repositories;

public class ReceptionistsRepository : RepositoryBase<Receptionist>, IReceptionistsRepository
{
    public ReceptionistsRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public override async Task CreateAsync(Receptionist receptionist, CancellationToken cancellationToken)
    {
        var query = $"INSERT INTO {TableName} (Id, AccountId, FirstName, LastName, MiddleName, OfficeId) VALUES (@Id, @AccountId, @FirstName, @LastName, @MiddleName, @OfficeId)";
        using var connection = _dbContext.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync(query, receptionist);
        connection.Close();
    }

    public override async Task UpdateAsync(Receptionist receptionist, CancellationToken cancellationToken)
    {
        var query = $"UPDATE {TableName} SET AccountId = @AccountId, FirstName = @FirstName, LastName = @LastName, MiddleName = @MiddleName, OfficeId = @OfficeId WHERE Id = @Id";
        using var connection = _dbContext.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync(query, receptionist);
        connection.Close();
    }
}