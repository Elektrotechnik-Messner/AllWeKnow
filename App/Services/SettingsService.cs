using AllWeKnow.App.Database.Models;
using AllWeKnow.App.Repository;

namespace AllWeKnow.App.Services;

public class SettingsService
{
    public Repository<Setting> Settings;

    public SettingsService(Repository<Setting> settings)
    {
        Settings = settings;
    }

    public List<Setting> GetAll()
    {
        return Settings.Get().ToList();
    }

    public Setting GetByName(string name)
    {
        return Settings.Get().FirstOrDefault(x => x.Name == name);
    }
    public Setting GetById(string id)
    {
        return Settings.Get().FirstOrDefault(x => x.Id == id);
    }
}