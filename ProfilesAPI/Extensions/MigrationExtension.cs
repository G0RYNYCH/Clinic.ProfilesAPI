using FluentMigrator.Runner;
using ProfilesAPI.Migrations;

namespace ProfilesAPI.Extensions;

public static class MigrationExtension
{
    public static IApplicationBuilder Migrate(this IApplicationBuilder app, string connectionString)
    {
        Database.EnsureCreated(connectionString, "Profiles");

        using var scope = app.ApplicationServices.CreateScope();
        var runner = scope.ServiceProvider.GetService<IMigrationRunner>();
        runner.ListMigrations();
        runner.MigrateUp();//to roll back changes use MigrateDown

        return app;
    }
}