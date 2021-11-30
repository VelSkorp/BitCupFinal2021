using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace Bit_Cup2021
{
    public static class ConfigData
    {
        public static string EpamCareersUrl => ConfigFile.GetValue<string>("epamCareersUrl");
        private static ISettingsFile ConfigFile = new JsonSettingsFile("Config.json");
    }
}