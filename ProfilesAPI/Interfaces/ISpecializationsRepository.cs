using ProfilesAPI.Models;

namespace ProfilesAPI.Interfaces;

public interface ISpecializationsRepository : IRepositoryBase<Specialization>
{
    Task CreateAsync(Specialization specialization, CancellationToken cancellationToken);

    Task UpdateAsync(Specialization specialization, CancellationToken cancellationToken);
}