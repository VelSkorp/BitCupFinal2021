using Aquality.Selenium.Browsers;
using NUnit.Framework;
using System.IO;
using System;

namespace Bit_Cup2021
{
	public class TestCase
	{
		private const string baseFilePath = @"resources\careers\Vlad_Kontsevich_";

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
			epamCareersForm.FindJob();
			var findJobResultsForm = Bit_CupTestSteps.CreateAndWaitForFormDisplayed<FindJobResultsForm>();
			var filepath = $"{AppDomain.CurrentDomain.BaseDirectory}{baseFilePath}{DateTime.Now:MM\\/dd\\/yyyy_HH:mm}.csv";

			System.Diagnostics.Debugger.Launch();
			using (StreamWriter writer = new StreamWriter(new FileStream(filepath, FileMode.Create, FileAccess.Write)))
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