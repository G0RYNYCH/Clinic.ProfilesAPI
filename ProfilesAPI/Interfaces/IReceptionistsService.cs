using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Interfaces;

public interface IReceptionistsService
{
    Task<IEnumerable<Receptionist>> GetAllAsync(PaginationDto dto, CancellationToken cancellationToken);

    Task<Receptionist> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task CreateAsync(ReceptionistDto dto, CancellationToken cancellationToken);

    Task UpdateAsync(ReceptionistDto dto, CancellationToken cancellationToken);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}