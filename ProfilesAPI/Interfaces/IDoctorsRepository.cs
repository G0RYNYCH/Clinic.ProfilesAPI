using ProfilesAPI.Models;

namespace ProfilesAPI.Interfaces;

public interface IDoctorsRepository : IRepositoryBase<Doctor>
{
    Task<IEnumerable<Doctor>> GetDoctorsByOfficeIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<IEnumerable<Doctor>> GetDoctorsBySpecializationIdAsync(Guid id, CancellationToken cancellationToken);

    Task CreateAsync(Doctor doctor, CancellationToken cancellationToken);

    Task UpdateAsync(Doctor entity, CancellationToken cancellationToken);
}