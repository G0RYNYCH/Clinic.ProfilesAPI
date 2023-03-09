using Dapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;

namespace ProfilesAPI.Repositories;

public class DoctorsRepository : RepositoryBase<Doctor>, IDoctorsRepository
{
    public DoctorsRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Doctor>> GetDoctorsByOfficeIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var query = $"SELECT * FROM {TableName} WHERE OfficeId = {id}";
        using var connection = _dbContext.CreateConnection();
        connection.Open();
        var doctors = await connection.QueryAsync<Doctor>(query);
        connection.Close();

        return doctors;
    }

    public async Task<IEnumerable<Doctor>> GetDoctorsBySpecializationIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var query = $"SELECT * FROM {TableName} WHERE SpeciallizationId = {id}";
        using var connection = _dbContext.CreateConnection();
        connection.Open();
        var doctors = await connection.QueryAsync<Doctor>(query);
        connection.Close();

        return doctors;
    }

    public override async Task CreateAsync(Doctor doctor, CancellationToken cancellationToken)
    {
        var query = $"INSERT INTO {TableName} (Id, AccountId, FirstName, LastName, MiddleName, DateOfBirth, SpeciallizationId, OfficeId, CareerStartYear, Status) VALUES (@Id, @AccountId, @FirstName, @LastName, @MiddleName, @DateOfBirth, @SpeciallizationId, @OfficeId, @CareerStartYear, @Status)";
        using var connection = _dbContext.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync(query, doctor);
        connection.Close();
    }

    public override async Task UpdateAsync(Doctor doctor, CancellationToken cancellationToken)
    {
        var query = $"UPDATE {TableName} SET AccountId = @AccountId, FirstName = @FirstName, LastName = @LastName, MiddleName = @MiddleName, DateOfBirth = @DateOfBirth, SpeciallizationId = @SpeciallizationId, OfficeId = @OfficeId, CareerStartYear = @CareerStartYear, Status = @Status WHERE Id = @Id";
        using var connection = _dbContext.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync(query, doctor);
        connection.Close();
    }
}