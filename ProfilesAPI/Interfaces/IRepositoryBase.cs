using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Interfaces;

public interface IRepositoryBase<T>
{
    Task<IEnumerable<T>> GetAllAsync(PaginationDto dto, CancellationToken cancellationToken);

    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    
    Task CreateAsync(T entity, CancellationToken cancellationToken);
    
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
}