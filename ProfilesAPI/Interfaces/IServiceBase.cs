using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Interfaces;

public interface IServiceBase<T>
{
    Task<IEnumerable<T>> GetAllAsync(PaginationDto dto, CancellationToken cancellationToken);

    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}