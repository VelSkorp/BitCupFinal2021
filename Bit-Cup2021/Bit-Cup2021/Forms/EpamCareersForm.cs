using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Bit_Cup2021
{
    public class EpamCareersForm : Form
    {
        private IButton LocationSelector => ElementFactory.GetButton(By.XPath("//button[@class='location-selector__button']"), "Location selector button");
        private IButton GlobalEnglishSelector => ElementFactory.GetButton(By.XPath("//ul[@class='location-selector__list']//a[@lang='en' and contains(text(),'Global')]"), "Global english selector button");

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
    }
}