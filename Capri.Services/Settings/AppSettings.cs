using Sieve.Attributes;

namespace Capri.Services.Settings
{
    public class AppSettings
    {
        public string DbConnectionString { get; set; }
        public SystemSettings SystemSettings { get; set; }
        public JwtAuthorizationDetails JwtAuthorizationDetails { get; set; }
        public SieveSettings SieveSettings { get; set; }
        public Logging Logging { get; set; }
    }
}