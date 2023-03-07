using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;

namespace ProfilesAPI.Repositories;

public class PatientsRepository : RepositoryBase<Patient>, IPatientsRepository
{
    public PatientsRepository(DbContext dbContext) : base(dbContext)
    {
    }
}