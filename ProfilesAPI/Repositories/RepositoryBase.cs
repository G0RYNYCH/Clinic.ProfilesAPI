﻿using Dapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T>
{
    protected readonly string TableName;
    protected readonly DbContext _dbContext;

    protected RepositoryBase(DbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        TableName = typeof(T).Name + "s";
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
        var query = $"SELECT * FROM {TableName} WHERE Id = '{id}'";
        using var connection = _dbContext.CreateConnection();
        connection.Open();
        var result = await connection.QuerySingleOrDefaultAsync<T>(query);
        connection.Close();

        return result;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var query = $"DELETE FROM {TableName} WHERE Id = '{id}'";
        using var connection = _dbContext.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync(query);
        connection.Close();
    }

    public virtual Task CreateAsync(T entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
    public virtual Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}