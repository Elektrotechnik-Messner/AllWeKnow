using AllWeKnow.App.Configuration;
using Logging.Net;

namespace AllWeKnow.App.Helpers;

public class ConfigHelper
{
    public ConfigHelper()
    {
        
    }

    public Task Perform()
    {
        Logger.Info("Checking config file");
        var path = PathBuilder.File("storage", "config.json");

        if (File.Exists(path))
        {
            Logger.Info("Config file exists, continuing startup");
            return Task.CompletedTask;
        }

        FileStream fs = File.Create(path);
        fs.Close();
        return Task.CompletedTask;
    }
}