using AllWeKnow.App.Configuration;
using AllWeKnow.App.Database.Models;
using AllWeKnow.App.Configuration;
using AllWeKnow.App.Repository;

namespace AllWeKnow.App.Services;

public class SettingsService
{

    private readonly ConfigService ConfigService;

    private ConfigModel.SettingsData settingsData;

    public SettingsService(ConfigService configService)
    {
        ConfigService = configService;
        settingsData = ConfigService.Get().Settings;
    }

    public string GetAppTitle()
    {
        return settingsData.AppTitle;
    }
    
    public string GetAppName()
    {
        return settingsData.AppName;
    }
    
    public int GetMaxArticles()
    {

        return settingsData.MaxPostsShowing;
    }






}