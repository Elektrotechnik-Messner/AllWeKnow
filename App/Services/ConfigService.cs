/*
 * Date: 2023-11-28
 * 
 * Code from https://github.com/Moonlight-Panel/Moonlight
 * 
 * LICENSE.md https://github.com/Moonlight-Panel/Moonlight/blob/main/LICENSE.md
 */

using AllWeKnow.App.Configuration;
using Newtonsoft.Json;

namespace AllWeKnow.App.Services;

public class ConfigService
{
    private readonly string Path = "storage/config.json";
    private ConfigModel Data;
    
    public ConfigService()
    {
        if(!Directory.Exists("storage"))
        {
            Directory.CreateDirectory(  "storage");
        }
        
        Reload();
    }

    public void Reload()
    {
        if(!File.Exists(Path))
            File.WriteAllText(Path, "{}");

        var text = File.ReadAllText(Path);
        Data = JsonConvert.DeserializeObject<ConfigModel>(text) ?? new();
        Save();
    }

    public void Save()
    {
        var text = JsonConvert.SerializeObject(Data, Formatting.Indented);
        File.WriteAllText(Path, text);
    }

    public ConfigModel Get()
    {
        return Data;
    }
}