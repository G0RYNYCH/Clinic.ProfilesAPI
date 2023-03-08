using ProfilesAPI.Models;

namespace ProfilesAPI.Interfaces;

public interface IReceptionistsRepository : IRepositoryBase<Receptionist>
{
    Task CreateAsync(Receptionist receptionist, CancellationToken cancellationToken);

    Task UpdateAsync(Receptionist receptionist, CancellationToken cancellationToken);
}