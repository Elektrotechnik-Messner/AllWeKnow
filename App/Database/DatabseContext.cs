/*
 * Date: 2023-11-28
 * 
 * Code from https://github.com/Moonlight-Panel/Moonlight
 * 
 * LICENSE.md https://github.com/Moonlight-Panel/Moonlight/blob/main/LICENSE.md
 */

using AllWeKnow.App.Services;
using Microsoft.EntityFrameworkCore;

namespace AllWeKnow.App.Database;

public class DataContext : DbContext
{
    private readonly ConfigService ConfigService;
    
    //Ref
    //public Repository<UserModel> User;
    //Exm: (Can be Null)
    //User.Get().FirstOrDefault(x => x.Username == "NevaGonnaGiveYouUp");
    
    //Models
    //public DbSet<User> Users { get; set; }
    //public DbSet<BlogPost> BlogPost { get; set; }
    //public DbSet<SettingsModel> SettingsModel { get; set; }
    //public DbSet<SubjectModel> SubjectModel { get; set; }
    //public DbSet<UploadResult> UploadResult { get; set; }
    //public DbSet<UserModel> UserModel { get; set; }

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