using Dapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;

namespace ProfilesAPI.Repositories;

public class SpecializationsRepository: RepositoryBase<Specialization>, ISpecializationsRepository
{
    public SpecializationsRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public override async Task CreateAsync(Specialization specialization, CancellationToken cancellationToken)
    {
        var query = $"INSERT INTO {TableName} (Id, SpecializationName, IsActive) VALUES (@Id, @SpecializationName, @IsActive)";

        using var connection = _dbContext.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync(query, specialization);
        connection.Close();
    }

    public override async Task UpdateAsync(Specialization specialization, CancellationToken cancellationToken)
    {
        var query = $"UPDATE {TableName} SET SpecializationName = @SpecializationName, IsActive = @IsActive WHERE Id = @Id";
        using var connection = _dbContext.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync(query, specialization);
        connection.Close();
    }
}