using FluentMigrator.Runner;
using ProfilesAPI.Migrations;

namespace ProfilesAPI.Extensions;

public static class MigrationExtension
{
    public static IApplicationBuilder Migrate(this IApplicationBuilder app, string connectionString)
    {
        Database.EnsureCreated(connectionString, "Accounts");
        return app;
    }
}