﻿using System.Reflection;
using FluentMigrator.Runner;
using ProfilesAPI.Extensions;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Repositories;

namespace ProfilesAPI;

public class StartUp
{
    public IConfiguration Configuration { get; }

    public StartUp(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton<DbContext>();
        services.AddScoped<IAccountsRepository, AccountsRepository>();
        services
            .AddLogging(x => x.AddFluentMigratorConsole())
            .AddFluentMigratorCore()
            .ConfigureRunner(x => x
                .AddSqlServer()
                .WithGlobalConnectionString(Configuration.GetConnectionString("DbConnection"))
                .ScanIn(Assembly.GetExecutingAssembly())
            );
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Migrate(Configuration.GetConnectionString("MasterDbConnection"));//Use MasterDbConnection, not DbConnection
    }
}