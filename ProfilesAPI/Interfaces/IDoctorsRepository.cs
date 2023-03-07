using ProfilesAPI.Models;

namespace ProfilesAPI.Interfaces;

public interface IDoctorsRepository
{
    Task<Doctor> GetDoctorByOfficeId(Guid id, CancellationToken cancellationToken);
    
    Task<Doctor> GetDoctorBySpecializationId(Guid id, CancellationToken cancellationToken);
}