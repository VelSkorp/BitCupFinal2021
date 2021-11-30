using Aquality.Selenium.Browsers;
using NUnit.Framework;

namespace Bit_Cup2021
{
    public class TestCase
    {
        [SetUp]
        public void BeforeTest()
        {
            AqualityServices.Browser.Maximize();
            AqualityServices.Browser.GoTo(ConfigData.EpamCareersUrl);
        }

        [Test]
        public static void Test()
        {
            var epamCareersForm = Bit_CupTestSteps.CreateAndWaitForFormDisplayed<EpamCareersForm>();
            System.Diagnostics.Debugger.Launch();
            epamCareersForm.ClickLocationSelectorButton();
            epamCareersForm.SelectGlobalEnglish();
        }

        [TearDown]
        public void AfterTest()
        {
            if (AqualityServices.IsBrowserStarted)
            {
                AqualityServices.Browser.Quit();
            }
        }
    }
}