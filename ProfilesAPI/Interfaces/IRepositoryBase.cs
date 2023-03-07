namespace ProfilesAPI.Interfaces;

public interface IRepositoryBase<T>
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);

    Task<T> GetById(Guid id, CancellationToken cancellationToken);

    //Task CreateAsync(T entity, CancellationToken cancellationToken);

    Task UpdateAsync(Guid id, CancellationToken cancellationToken);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}