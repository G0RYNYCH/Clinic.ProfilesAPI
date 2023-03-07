using ProfilesAPI.Models;

namespace ProfilesAPI.Interfaces;

public interface IDoctorsRepository : IRepositoryBase<Doctor>
{
    Task<Doctor> GetDoctorByOfficeId(Guid id, CancellationToken cancellationToken);
    
    Task<Doctor> GetDoctorBySpecializationId(Guid id, CancellationToken cancellationToken);
}