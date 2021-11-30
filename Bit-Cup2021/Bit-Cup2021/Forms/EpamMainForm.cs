using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Bit_Cup2021
{
    public class EpamMainForm : Form
    {
        private ILink FindYourDreamJobLink => ElementFactory.GetLink(By.XPath("//div[contains(@class,'section--padding-large')]//a[@class='button-ui bg-color-white standard']"), "Find Your Dream Job link");

        public EpamMainForm()
            : base(By.XPath("//div[@class='background-video parbase section background-video--relative'])"), "Epam main form")
        {
        }

        public void ClickFindYourDreamJobLink()
        {
            FindYourDreamJobLink.Click();
        }
    }
}