using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using Tests.Helpers;

namespace Tests.Pages
{
    public class Frontpage
    {
        private IWebDriver _driver;
        private Actions _builder;
        public string Name;

        [FindsBy(How = How.CssSelector, Using = Locators.Logo)]
        public IWebElement Logo;

        [FindsBy(How = How.CssSelector, Using = Locators.IntroText)]
        public IWebElement IntroText;

        [FindsBy(How = How.CssSelector, Using = Locators.NavigationLinks)]
        public IList<IWebElement> NavigationLinks;

        [FindsBy(How = How.CssSelector, Using = Locators.StartBtn)]
        public IWebElement StartBtn;

        [FindsBy(How = How.CssSelector, Using = Locators.StartBtnText)]
        public IWebElement StartBtnText;

        [FindsBy(How = How.CssSelector, Using = Locators.NavDots)]
        public IWebElement NavDots;

        public Frontpage(IWebDriver driver)
        {
            _driver = driver;
            _builder = new Actions(_driver);
            PageFactory.InitElements(_driver, this);
            Name = driver.Title;
        }

        public void Click_AndHold(IWebElement button)
        {
            _builder.ClickAndHold(button).Perform();
            //Thread.Sleep(8000);
        }


    }
}
