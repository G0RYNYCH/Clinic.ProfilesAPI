using Dapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;

namespace ProfilesAPI.Repositories;

public class SpecializationsRepository: RepositoryBase<Specialization>, ISpecializationsRepository
{
    private const string TableName = "Specializations";
    private readonly DbContext _dbContext;
    
    public SpecializationsRepository(DbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));//TODO: initialize dbContext
    }

    public async Task CreateAsync(Specialization specialization, CancellationToken cancellationToken)
    {
        var query = $"INSERT INTO {TableName} (Id, SpecializationName, IsActive) VALUES (@Id, @SpecializationName, @IsActive)";//TODO: make columns names private consts

        using var connection = _dbContext.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync(query, specialization);
        connection.Close();
    }

    public async Task UpdateAsync(Specialization specialization, CancellationToken cancellationToken)
    {
        var query = $"UPDATE {TableName} SET SpecializationName = @SpecializationName, IsActive = @IsActive WHERE Id = @Id";
        using var connection = _dbContext.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync(query, specialization);
        connection.Close();
    }

    // public async Task<IEnumerable<Specialization>> GetAllAsync(PaginationDto dto, CancellationToken ct)
    // {
    //     var query = $"SELECT * FROM {TableName} ORDER BY Id OFFSET {(dto.PageNumber - 1) * dto.PageSize} ROWS FETCH NEXT {dto.PageSize} ROWS ONLY;";
    //     using var connection = _dbContext.CreateConnection();
    //     connection.Open();
    //     var specializations = await connection.QueryAsync<Specialization>(query);
    //     connection.Close();
    //
    //     return specializations;
    // }

    // public async Task<Specialization> GetByIdAsync(Guid id, CancellationToken ct)
    // {
    //     var query = $"SELECT * FROM {TableName} WHERE Id = {id}";
    //     using var connection = _dbContext.CreateConnection();
    //     connection.Open();
    //     var result = await connection.QuerySingleOrDefaultAsync<Specialization>(query);
    //     connection.Close();
    //
    //     return result;
    // }

    // public async Task DeleteAsync(Guid id, CancellationToken ct)
    // {
    //     var query = $"DELETE FROM {TableName} WHERE Id = {id}";
    //     using var connection = _dbContext.CreateConnection();
    //     connection.Open();
    //     await connection.ExecuteAsync(query);
    //     connection.Close();
    // }
}