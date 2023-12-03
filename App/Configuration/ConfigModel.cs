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
}