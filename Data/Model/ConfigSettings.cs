namespace Data.Model
{
    public class ConfigSettings
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public Mongosettings MongoSettings { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
    }

    public class Mongosettings
    {
        public string ConnectionBook { get; set; }
        public string Connection { get; set; }
        public string DatabaseName { get; set; }
    }
}
