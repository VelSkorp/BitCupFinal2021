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
			epamCareersForm.ClickLocationSelectorButton();
			epamCareersForm.SelectGlobalEnglish();
			var epamMainForm = Bit_CupTestSteps.CreateAndWaitForFormDisplayed<EpamMainForm>();
			epamMainForm.ClickFindYourDreamJobLink();
			epamCareersForm.EnterNewFormJobKeyword(TestData.NewFormJobKeyword);
			epamCareersForm.ClickJobLocationSelector();
			epamCareersForm.ClickJobLocationCountryOption(TestData.LocationCountry);
			epamCareersForm.ClickJobLocationTownOption(TestData.LocationTown);
			epamCareersForm.ClickJobSkillsSelector();
			epamCareersForm.SelectJobSkillsOption(TestData.Skills);
			epamCareersForm.ClickJobSkillsSelector();
			epamCareersForm.SelectIsJobRemote(TestData.Remote);

			System.Diagnostics.Debugger.Launch();
			epamCareersForm.FindJob();
			var findJobResultsForm = Bit_CupTestSteps.CreateAndWaitForFormDisplayed<FindJobResultsForm>();
			var recruitingPageForm = Bit_CupTestSteps.CreateAndWaitForFormDisplayed<RecruitingPageForm>();
			for (int itemIndex = 0; itemIndex < findJobResultsForm.GetCountOfSearchResults(); itemIndex++)
			{
				findJobResultsForm.GoToSearchResultItem(itemIndex);
				Assert.IsTrue(recruitingPageForm.IsWhatYouHaveBlockContains(TestData.NewFormJobKeyword), $"What You Have block is not contains {TestData.NewFormJobKeyword}");

			}
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