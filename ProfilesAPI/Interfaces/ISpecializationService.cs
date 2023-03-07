using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Interfaces;

public interface ISpecializationService
{
    Task CreateAsync(CreateSpecializationDto specializationDto, CancellationToken cancellationToken);
}