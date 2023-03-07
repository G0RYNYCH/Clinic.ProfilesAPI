using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Interfaces;

public interface IPatientsService
{
    Task<IEnumerable<Patient>> GetAllAsync(CancellationToken cancellationToken);

    Task<Patient> GetById(Guid id, CancellationToken cancellationToken);

    Task CreateAsync(CreatePatientDto patientDto, CancellationToken cancellationToken);

    Task UpdateAsync(Guid id, CancellationToken cancellationToken);
    
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}