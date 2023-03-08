using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Interfaces;

public interface IDoctorsService
{
    Task<IEnumerable<Doctor>> GetAllAsync(PaginationDto dto, CancellationToken cancellationToken);
    
    Task<IEnumerable<Doctor>> GetDoctorsByOfficeId(Guid id, CancellationToken cancellationToken);
    
    Task<IEnumerable<Doctor>> GetDoctorsBySpecializationId(Guid id, CancellationToken cancellationToken);

    Task<Doctor> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task CreateAsync(DoctorDto dto, CancellationToken cancellationToken);

    Task UpdateAsync(DoctorDto dto, CancellationToken cancellationToken);
    
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}