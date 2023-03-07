using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;

namespace ProfilesAPI.Repositories;

public class ReceptionistsRepository : RepositoryBase<Receptionist>, IReceptionistsRepository
{
    public ReceptionistsRepository(DbContext dbContext) : base(dbContext)
    {
    }
}