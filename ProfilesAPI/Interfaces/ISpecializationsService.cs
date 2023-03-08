using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Interfaces;

public interface ISpecializationsService
{
    Task CreateAsync(CreateSpecializationDto dto, CancellationToken cancellationToken);
}