using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Bit_Cup2021
{
    public class FindJobResultsForm : Form
    {
        private IList<ILink> SearchResultItems => ElementFactory.FindElements<ILink>(By.XPath("//div[@class='search-result__item-info']//a"), "Find Your Dream Job link");

        public FindJobResultsForm()
            : base(By.XPath("//ul[@class='search-result__list']"), "Find job results form")
        {
        }

        public void GoToSearchResultItem(int itemIndex)
        {
            SearchResultItems[itemIndex].Click();
        }

        public int GetCountOfSearchResults()
        {
            return SearchResultItems.Count;
        }
    }
}