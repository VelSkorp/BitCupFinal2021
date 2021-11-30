using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Bit_Cup2021
{
	public class RecruitingPageForm : Form
	{
		private IList<ITextBox> WhatYouHaveBlockItems => ElementFactory.FindElements<ITextBox>(By.XPath("(//ul[@class='bullet-list'])[2]//li"), "What You Have block items");
		private ILabel JobTitle => ElementFactory.GetLabel(By.XPath("//header[@class='recruiting-page__header']//h1"), "Job title label");
		private ILabel JobDescription => ElementFactory.GetLabel(By.XPath("//div[@class='recruiting-page__top-description']"), "Job description label");
		private ILabel Job => ElementFactory.GetLabel(By.XPath("//strong[@class='vacancy-page__id']"), "Job description label");

		public RecruitingPageForm()
			: base(By.XPath("//header[@class='recruiting-page__header']"), "Recruiting page form")
		{
		}

		public bool IsWhatYouHaveBlockContains(string value)
		{
			foreach (var item in WhatYouHaveBlockItems)
			{
				if (item.Text.Contains(value))
				{
					return true;
				}
			}
			return false;
		}

		public string GetJobTitle()
		{
			return JobTitle.Text;
		}

		public string GetJobDescription()
		{
			return JobDescription.Text;
		}

		public string GetJob()
		{
			return Job.Text;
		}
	}
}