using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.Helpers;

namespace Tests.Pages
{
    public class Frontpage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = Locators.Logo)]
        private IWebElement Logo;

        [FindsBy(How = How.CssSelector, Using = Locators.IntroText)]
        private IWebElement IntroText;

        [FindsBy(How = How.CssSelector, Using = Locators.NavigationLinks)]
        private IList<IWebElement> NavigationLinks;

        [FindsBy(How = How.CssSelector, Using = Locators.StartBtn)]
        private IWebElement StartBtn;

        [FindsBy(How = How.CssSelector, Using = Locators.StartBtnText)]
        private IWebElement StartBtnText;

        public Frontpage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
    }
}
