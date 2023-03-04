using ProfilesAPI;
using ProfilesAPI.Extensions;

CreateHostBuilder(args)
    .Build()
    .MigrateDatabase()
    .Run();

IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<StartUp>();
        });
