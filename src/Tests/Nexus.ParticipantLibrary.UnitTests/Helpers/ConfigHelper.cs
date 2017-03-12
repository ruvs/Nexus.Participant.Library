using System.Configuration;

namespace Nexus.ParticipantLibrary.UnitTests.Helpers
{
    public class ConfigHelper
    {
        public static string GetAppSetting(string appSetting)
        {
            if (ConfigurationManager.AppSettings[appSetting] != null)
                return ConfigurationManager.AppSettings[appSetting];
            return string.Empty;
        }
    }
}
