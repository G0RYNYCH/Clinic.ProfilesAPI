using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;

namespace ProfilesAPI.Repositories;

public class SpecializationRepository: RepositoryBase<Specialization>, ISpecializationRepository
{
    public SpecializationRepository(DbContext dbContext) : base(dbContext)
    {
    }
}