using Aquality.Selenium.Browsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bit_Cup2021
{
	[TestClass]
    public class TestCase
	{
		private const string baseFilePath = @"resources\careers\";

		[TestInitialize]
		public void BeforeTest()
		{
			AqualityServices.Browser.Maximize();
			AqualityServices.Browser.GoTo(ConfigData.EpamCareersUrl);
		}

		[TestMethod]
		public void Test()
		{
			var epamCareersForm = Bit_CupTestSteps.CreateAndWaitForFormDisplayed<EpamCareersForm>();
			epamCareersForm.ClickLocationSelectorButton();
			epamCareersForm.SelectGlobalEnglish();
			var epamMainForm = Bit_CupTestSteps.CreateAndWaitForFormDisplayed<EpamMainForm>();
			epamMainForm.AcceptCookies();
			epamMainForm.ClickFindYourDreamJobLink();
			epamCareersForm.EnterNewFormJobKeyword(TestData.NewFormJobKeyword);
			epamCareersForm.ClickJobLocationSelector();
			epamCareersForm.ClickJobLocationCountryOption(TestData.LocationCountry);
			epamCareersForm.ClickJobLocationTownOption(TestData.LocationTown);
			epamCareersForm.ClickJobSkillsSelector();
			epamCareersForm.SelectJobSkillsOption(TestData.Skills);
			epamCareersForm.ClickJobSkillsSelector();
			epamCareersForm.SelectIsJobRemote(TestData.Remote);
			epamCareersForm.FindJob();
			var findJobResultsForm = Bit_CupTestSteps.CreateAndWaitForFormDisplayed<FindJobResultsForm>();
			var directorypath = $"{AppDomain.CurrentDomain.BaseDirectory}{baseFilePath}";
			Directory.CreateDirectory(directorypath);
			using (StreamWriter writer = new StreamWriter(File.Create($"{directorypath}Vlad_Kontsevich_{DateTime.Now:MM.dd.yyyy}.csv")))
			{
				for (int itemIndex = 0; itemIndex < findJobResultsForm.GetCountOfSearchResults(); itemIndex++)
				{
					findJobResultsForm.GoToSearchResultItem(itemIndex);
					var recruitingPageForm = Bit_CupTestSteps.CreateAndWaitForFormDisplayed<RecruitingPageForm>();
					Assert.IsTrue(recruitingPageForm.IsWhatYouHaveBlockContains(TestData.NewFormJobKeyword), $"What You Have block is not contains {TestData.NewFormJobKeyword}");
					writer.WriteLine(recruitingPageForm.GetJobTitle());
					writer.WriteLine(AqualityServices.Browser.CurrentUrl);
					writer.WriteLine(recruitingPageForm.GetJobDescription());
					writer.WriteLine(recruitingPageForm.GetJob());
				}
			}
		}

		[TestCleanup]
		public void AfterTest()
		{
			if (AqualityServices.IsBrowserStarted)
			{
				AqualityServices.Browser.Quit();
			}
		}
	}
}