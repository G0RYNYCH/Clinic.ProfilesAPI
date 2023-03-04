using Dapper;
using ProfilesAPI.Repositories;

namespace ProfilesAPI.Migrations;

public class Database
{
    private readonly DbContext _dbContext;

    public Database(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateDatabase(string dbName)
    {
        var query = "SELECT * FROM sys.database WHERE name = @name";
        var parameters = new DynamicParameters();
        parameters.Add("Profiles", dbName);

        using (var connection = _dbContext.CreateMasterConnection())
        {
            var records = connection.QueryAsync(query, parameters);
            if (!records.Result.Any())
                connection.ExecuteAsync($"CREATE DATABASE {dbName}");
        }
    }
}