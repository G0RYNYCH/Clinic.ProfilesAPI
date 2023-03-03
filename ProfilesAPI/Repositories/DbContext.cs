using System.Data;
using Microsoft.Data.SqlClient;

namespace ProfilesAPI.Repositories;

public class DbContext
{
    private readonly IConfiguration _configuration;//TODO: convert to local variable
    private readonly string _connectionString;

    public DbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DbConnection");
    }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}