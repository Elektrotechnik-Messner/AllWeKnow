using AllWeKnow.App.Configuration;
using AllWeKnow.App.Database;
using AllWeKnow.App.Services;
using Logging.Net;
using Microsoft.EntityFrameworkCore;

namespace AllWeKnow.App.Helpers;

public class DatabaseCheckup
{
    private readonly ConfigService ConfigService;

    public DatabaseCheckup(ConfigService configService)
    {
        ConfigService = configService;
    }

    public async Task Perform()
    {
        var context = new DataContext(ConfigService);

        
        Logger.Info("Checking database");
        
        if (!await context.Database.CanConnectAsync())
        {
            Logger.Fatal("-----------------------------------------------");
            Logger.Fatal("Unable to connect to mysql database");
            Logger.Fatal("Please make sure the configuration is correct");
            Logger.Fatal("");
            Logger.Fatal("The App will wait 1 minute, then exit");
            Logger.Fatal("-----------------------------------------------");
            
            Thread.Sleep(TimeSpan.FromMinutes(1));
            Environment.Exit(10324);
        }

        Logger.Info("Checking for pending migrations");

        var migrations = (await context.Database
            .GetPendingMigrationsAsync())
            .ToArray();

        if (migrations.Any())
        {
            Logger.Info($"{migrations.Length} migrations pending. Updating now");
            
            
            Logger.Info("Applying migrations");
            
            await context.Database.MigrateAsync();
            
            Logger.Info("Successfully applied migrations");
        }
        else
        {
            Logger.Info("Database is up-to-date. No migrations have been performed");
        }
    }
}