using Dapper;
using ProfilesAPI.Interfaces;

namespace ProfilesAPI.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T>
{
    private readonly DbContext _dbContext;
    private readonly string _tableName;

    public RepositoryBase(DbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _tableName = nameof(T) + "s";
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        var query = $"SELECT * FROM {_tableName}";
        using var connection = _dbContext.CreateConnection();
        connection.Open();
        var result = await connection.QueryAsync<T>(query, cancellationToken);
        connection.Close();
        
        return result.ToList();
    }

    public async Task<T> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = $"SELECT * FROM {_tableName} WHERE Id = {id}";
        using var connection = _dbContext.CreateConnection();
        var result = await connection.QuerySingleOrDefaultAsync<T>(query);

        return result;
    }

    // public Task CreateAsync(T entity, CancellationToken cancellationToken)
    // {
    //     throw new NotImplementedException();
    // }

    public Task UpdateAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}