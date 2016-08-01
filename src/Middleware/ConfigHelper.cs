using System.Configuration;

namespace Nexus.ParticipantLibrary.Middleware
{
    public static class ConfigHelper
    {
        private static readonly string CORS_ORIGINS_SETTINGS_KEY = "CorsOrigins";
        public static string CorsOrigins
        {
            get { return ConfigurationManager.AppSettings[CORS_ORIGINS_SETTINGS_KEY]; }
        }
    }
}
