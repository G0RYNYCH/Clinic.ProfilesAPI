using System.Security;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ProfilesAPI.Migrations;

public static class Database
{
    public static void EnsureCreated(string connectionString, string name)
    {
        var parameters = new DynamicParameters();
        parameters.Add("name", name);
        
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        var records = connection.Query("SELECT * FROM sys.Databases WHERE name = @name", parameters);
        if (!records.Any())
            connection.Execute($"CREATE DATABASE {name}");
        connection.Close();
    }
}