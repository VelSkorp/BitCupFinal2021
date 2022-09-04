using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace Bit_Cup2021
{
    public static class TestData
    {
        public static string NewFormJobKeyword => TestDataFile.GetValue<string>("newFormJobKeyword");
        public static string LocationCountry => TestDataFile.GetValue<string>("location.country");
        public static string LocationTown => TestDataFile.GetValue<string>("location.town");
        public static string Skills => TestDataFile.GetValue<string>("skills");
        public static bool Remote => TestDataFile.GetValue<bool>("remote");
        private static ISettingsFile TestDataFile = new JsonSettingsFile("TestData.json");
    }
}