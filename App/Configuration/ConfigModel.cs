using Newtonsoft.Json;

namespace AllWeKnow.App.Configuration;

public class ConfigModel
{
    [JsonProperty("Database")] public DatabaseData Database { get; set; } = new();
    
    public class DatabaseData
    {
        [JsonProperty("Host")]
        public string Host { get; set; } = "your.db.host";
        
        [JsonProperty("Port")]
        public int Port { get; set; } = 3306;
        
        [JsonProperty("Username")]
        public string Username { get; set; } = "db_user";
        
        [JsonProperty("Password")]
        public string Password { get; set; } = "s3cr3t";
        
        [JsonProperty("Database")]
        public string Database { get; set; } = "database";
    }
    
    [JsonProperty("Settings")] public SettingsData Settings { get; set; } = new();
    
    public class SettingsData
    {
        [JsonProperty("Name")]
        public string AppName { get; set; } = "App Name";
        
        [JsonProperty("Title")]
        public string AppTitle { get; set; } = "Title";
        
        [JsonProperty("MaxPostsShowing")]
        public int MaxPostsShowing { get; set; } = 5;

        
        
        [JsonProperty("Safety")] public SafetyData Safety { get; set; } = new();

        public class SafetyData
        {
            [JsonProperty("ArticlesGetChecked")]
            public bool ArticlesGetChecked { get; set; } = false;
            
            [JsonProperty("AuthorityName")]
            public string AuthorityName { get; set; } = "Lehrer";
        }
        

    }
    
}