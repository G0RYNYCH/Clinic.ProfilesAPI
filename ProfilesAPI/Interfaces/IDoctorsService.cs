using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Interfaces;

public interface IDoctorsService
{
    Task<IEnumerable<Doctor>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<Doctor> GetDoctorByOfficeId(Guid id, CancellationToken cancellationToken);
    
    Task<Doctor> GetDoctorBySpecializationId(Guid id, CancellationToken cancellationToken);

    Task<Doctor> GetById(Guid id, CancellationToken cancellationToken);

    Task CreateAsync(CreateDoctorDto doctorDto, CancellationToken cancellationToken);

    Task UpdateAsync(Guid id, CancellationToken cancellationToken);
    
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}