/*
 * Date: 2023-11-28
 * 
 * Code from https://github.com/Moonlight-Panel/Moonlight
 * 
 * LICENSE.md https://github.com/Moonlight-Panel/Moonlight/blob/main/LICENSE.md
 */

using AllWeKnow.App.Database.Models;
using AllWeKnow.App.Services;
using Microsoft.EntityFrameworkCore;

namespace AllWeKnow.App.Database;

public class DataContext : DbContext
{
    private readonly ConfigService ConfigService;

    public DbSet<User> Users { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Setting> Settings { get; set; }
    
    public DataContext(ConfigService configService)
    {
        ConfigService = configService;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var config = ConfigService.Get().Database;
            
            var connectionString = $"host={config.Host};" +
                                   $"port={config.Port};" +
                                   $"database={config.Database};" +
                                   $"uid={config.Username};" +
                                   $"pwd={config.Password}";
            
            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString),
                builder => builder.EnableRetryOnFailure(5)
            );
        }
    }
}