using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;

namespace ProfilesAPI.Repositories;

public class DoctorsRepository : RepositoryBase<Doctor>, IDoctorsRepository
{
    public DoctorsRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public Task<Doctor> GetDoctorByOfficeId(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Doctor> GetDoctorBySpecializationId(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
    public Task CreateAsync(Doctor doctor, CancellationToken cancellationToken)
    {
        // var query = "INSERT INTO Doctors (Id, FirstName, LastName, MiddleName, DateOfBirth, SpeciallizationId, )"
            
        throw new NotImplementedException();
    }
}