using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Interfaces;

public interface IPatientsService
{
    Task<IEnumerable<Patient>> GetAllAsync(PaginationDto dto, CancellationToken cancellationToken);

    Task<Patient> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task CreateAsync(PatientDto patientDto, CancellationToken cancellationToken);

    Task UpdateAsync(PatientDto patientDto, CancellationToken cancellationToken);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}