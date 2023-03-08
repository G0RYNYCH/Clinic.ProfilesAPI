using Dapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;

namespace ProfilesAPI.Repositories;

public class SpecializationsRepository: RepositoryBase<Specialization>, ISpecializationsRepository
{
    private readonly DbContext _dbContext;
    
    public SpecializationsRepository(DbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;//TODO: legal?
    }

    public new async Task CreateAsync(Specialization specialization, CancellationToken cancellationToken)
    {
        var query = "INSERT INTO Specializations (Id, SpecializationName, IsActive) VALUES (@Id, @SpecializationName, @IsActive)";

        using var connection = _dbContext.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync(query, specialization);
        connection.Close();
    }
}