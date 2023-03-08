using Dapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T>
{
    private const string TableName = nameof(T) + "s";
    private readonly DbContext _dbContext;

    protected RepositoryBase(DbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<T>> GetAllAsync(PaginationDto dto, CancellationToken cancellationToken)
    {
        var query = $"SELECT * FROM {TableName} ORDER BY Id OFFSET {(dto.PageNumber - 1) * dto.PageSize} ROWS FETCH NEXT {dto.PageSize} ROWS ONLY;";
        using var connection = _dbContext.CreateConnection();
        connection.Open();
        var result = await connection.QueryAsync<T>(query);
        connection.Close();

        return result;
    }

    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var query = $"SELECT * FROM {TableName} WHERE Id = {id}";
        using var connection = _dbContext.CreateConnection();
        connection.Open();
        var result = await connection.QuerySingleOrDefaultAsync<T>(query);
        connection.Close();

        return result;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var query = $"DELETE FROM {TableName} WHERE Id = {id}";
        using var connection = _dbContext.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync(query);
        connection.Close();
    }

    // public async Task CreateAsync(T entity, CancellationToken cancellationToken)
    // {
    //     var parameters = new DynamicParameters();
    //     var columnNames = new List<string>();
    //     var properties = typeof(T).GetProperties();
    //
    //     foreach (var property in properties)
    //     {
    //         parameters.Add(property.Name, property);
    //         columnNames.Add(property.Name);
    //     }
    //
    //     var query = $"INSERT INTO {_tableName} () VALUES ()";
    //
    //     using var connection = _dbContext.CreateConnection();
    //     connection.Open();
    //     await connection.ExecuteAsync(query, parameters);
    //     connection.Close();
    // }
}