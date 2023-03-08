using ProfilesAPI.Models;

namespace ProfilesAPI.Interfaces;

public interface IPatientsRepository : IRepositoryBase<Patient>
{
    Task CreateAsync(Patient patient, CancellationToken cancellationToken);

    Task UpdateAsync(Patient patient, CancellationToken cancellationToken);
}