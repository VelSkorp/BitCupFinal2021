using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Bit_Cup2021
{
	public class RecruitingPageForm : Form
	{
		private IList<ITextBox> WhatYouHaveBlockItems => ElementFactory.FindElements<ITextBox>(By.XPath("(//ul[@class='bullet-list'])[2]//li"), "Find Your Dream Job link");

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
	}
}