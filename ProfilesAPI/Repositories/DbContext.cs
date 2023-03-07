using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ProfilesAPI.Repositories;

public class DbContext
{
    private readonly IConfiguration _configuration;

    public DbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
        => new SqlConnection(_configuration.GetConnectionString("DbConnection"));

    public IDbConnection CreateMasterConnection()
        => new SqlConnection(_configuration.GetConnectionString("MasterDbConnection"));
}