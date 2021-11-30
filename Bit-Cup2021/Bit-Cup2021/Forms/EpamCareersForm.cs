using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Bit_Cup2021
{
	public class EpamCareersForm : Form
	{
		private IButton LocationSelector => ElementFactory.GetButton(By.XPath("//button[@class='location-selector__button']"), "Location selector button");
		private IButton GlobalEnglishSelector => ElementFactory.GetButton(By.XPath("//ul[@class='location-selector__list']//a[@lang='en' and contains(text(),'Global')]"), "Global english selector button");
		private IButton JobLocationSelector => ElementFactory.GetButton(By.XPath("//span[@role='combobox']"), "Job location selector button");
		private IButton JobSkillsSelector => ElementFactory.GetButton(By.XPath("//div[@role='combobox']"), "Job skills selector button");
		private IButton FindButton => ElementFactory.GetButton(By.XPath("//button[@type='submit']"), "Find button");
		private ITextBox NewFormJobKeyword => ElementFactory.GetTextBox(By.XPath("//input[@id='new_form_job_search_1445745853_copy-keyword']"), "Global english selector button");
		private ILabel JobRemote => ElementFactory.GetLabel(By.XPath("//input[@id='id-ce1e74aa-e69b-3bd2-9f9f-41628029ec68-remote']/parent::p"), "Job remote label");

		public EpamCareersForm()
			: base(By.XPath("//div[@class='background-video parbase section background-video--relative'])"), "Epam careers form")
		{
		}

		public void ClickLocationSelectorButton()
		{
			LocationSelector.Click();
		}

		public void SelectGlobalEnglish()
		{
			GlobalEnglishSelector.Click();
		}

		public void FindJob()
		{
			FindButton.Click();
		}

		public void SelectIsJobRemote(bool isRemote)
		{
			if (isRemote)
			{
				JobRemote.Click();
			}
		}

		public void SelectJobSkillsOption(string jobSkill)
		{
			GetJobSkillsOption(jobSkill).Click();
		}

		public void ClickJobLocationSelector()
		{
			JobLocationSelector.Click();
		}

		public void ClickJobSkillsSelector()
		{
			JobSkillsSelector.Click();
		}

		public void ClickJobLocationCountryOption(string jobLocationCountry)
		{
			GetJobLocationCountryOption(jobLocationCountry).Click();
		}

		public void ClickJobLocationTownOption(string jobLocationTown)
		{
			GetJobLocationTownOption(jobLocationTown).Click();
		}

		public void EnterNewFormJobKeyword(string keyword)
		{
			NewFormJobKeyword.ClearAndType(keyword);
		}

		private IButton GetJobLocationCountryOption(string jobLocationCountry)
		{
			return ElementFactory.GetButton(By.XPath($"//li[@aria-label='{jobLocationCountry}']"), $"Job location country option {jobLocationCountry} button");
		}

		private IButton GetJobLocationTownOption(string jobLocationTown)
		{
			return ElementFactory.GetButton(By.XPath($"//li[text()='{jobLocationTown}']"), $"Job location town option {jobLocationTown} button");
		}

		private ILabel GetJobSkillsOption(string jobSkill)
		{
			return ElementFactory.GetLabel(By.XPath($"//input[@type='checkbox' and @data-value='{jobSkill}']/parent::label"), $"Job skills option {jobSkill} button");
		}
	}
}