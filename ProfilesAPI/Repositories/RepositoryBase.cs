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
        connection.Open();
        var result = await connection.QuerySingleOrDefaultAsync<T>(query);
        connection.Close();
        
        return result;
    }

    public async Task CreateAsync(T entity, CancellationToken cancellationToken)
    {
        var parameters = new DynamicParameters();
        var columnNames = new List<string>();
        var properties = typeof(T).GetProperties();

        foreach (var property in properties)
        {
            parameters.Add(property.Name, property);
            columnNames.Add(property.Name);
        }
        
        var query = $"INSERT INTO {_tableName} () VALUES ()";

        using var connection = _dbContext.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync(query, parameters);
        connection.Close();
    }

    public Task UpdateAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}