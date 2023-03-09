using Dapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;

namespace ProfilesAPI.Repositories;

public class PatientsRepository : RepositoryBase<Patient>, IPatientsRepository
{
    public PatientsRepository(DbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task CreateAsync(Patient patient, CancellationToken cancellationToken)
    {
        var query = $"INSERT INTO {TableName} (Id, AccountId, FirstName, LastName, MiddleName, DateOfBirth, IsLinkedToAccount) VALUES (@Id, @AccountId, @FirstName, @LastName, @MiddleName, @DateOfBirth, @IsLinkedToAccount)";
        using var connection = _dbContext.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync(query, patient);
        connection.Close();
    }

    public async Task UpdateAsync(Patient patient, CancellationToken cancellationToken)
    {
        var query = $"UPDATE {TableName} SET AccountId = @AccountId, FirstName = @FirstName, LastName = @LastName, MiddleName = @MiddleName, DateOfBirth = @DateOfBirth, IsLinkedToAccount = @IsLinkedToAccount WHERE Id = @Id";
        using var connection = _dbContext.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync(query, patient);
        connection.Close();
    }
}