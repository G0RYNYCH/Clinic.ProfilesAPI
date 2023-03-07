using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Interfaces;

public interface IReceptionistsService
{
    Task<IEnumerable<Receptionist>> GetAllAsync(CancellationToken cancellationToken);

    Task<Receptionist> GetById(Guid id, CancellationToken cancellationToken);

    Task CreateAsync(CreateReceptionistDto receptionistDto, CancellationToken cancellationToken);

    Task UpdateAsync(Guid id, CancellationToken cancellationToken);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}