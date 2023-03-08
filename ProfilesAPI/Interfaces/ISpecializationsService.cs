using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Interfaces;

public interface ISpecializationsService
{
    Task<IEnumerable<Specialization>> GetAllAsync(PaginationDto dto, CancellationToken cancellationToken);

    Task<Specialization> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task CreateAsync(SpecializationDto dto, CancellationToken cancellationToken);

    Task UpdateAsync(SpecializationDto dto, CancellationToken cancellationToken);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}