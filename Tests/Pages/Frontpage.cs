using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Tests.Pages
{
    public class Frontpage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = ".encyclopedia__ingredients ul li")]
        private IList<IWebElement> Ingredients;

        [FindsBy(How = How.CssSelector, Using = ".encyclopedia__guids__list-item")]
        private IList<IWebElement> Guides;

        public Frontpage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
    }
}
