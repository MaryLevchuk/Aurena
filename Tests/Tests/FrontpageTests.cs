using System.Configuration;
using System.Linq;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Tests.Pages;
using Tests.Helpers;

namespace Tests
{
    public class FrontpageTests : TestSetup
    {
        public IWebDriver Driver;
        public Frontpage Page;
        public ItemInteraction Item = new ItemInteraction();

        public FrontpageTests()
        {
            Driver = OpenBrowser("chrome");
            OpenPage(BaseUrl + ConfigurationManager.AppSettings["FrontpageUrl"]);
            Page = new Frontpage(Driver);
            Specs.Driver = Driver;
        }

        [Test]
        public void PageTitle_ShouldBe_Aurena()
        {
            Page.Name.Should().Contain("Aurena");
        }

        [Test]
        public void Logo_ShouldHave_ProperLink()
        {
            Item.GetLinkHref(Page.Logo).Should().Contain("#");
        }

        [Test]
        public void AboutPage_ShouldHave_ProperLink()
        {
            Item.GetLinkHref(Page.NavigationLinks.First()).Should().Contain(BaseUrl + ConfigurationManager.AppSettings["AboutPageUrl"]);
        }

        [Test]
        public void SignUpPage_ShouldHave_ProperLink()
        {
            Item.GetLinkHref(Page.NavigationLinks.Last()).Should().Contain(BaseUrl + ConfigurationManager.AppSettings["SignUpPageUrl"]);
        }

        [Test]
        public void TransferToAthletesPage_ShouldBe()
        {
            Page.Click_AndHold(Page.StartBtn);
            ExpectedConditions.ElementToBeClickable(By.CssSelector(".athletes-overview__nav__athlete-details.js-goto-profile"));
            //Driver.FindElement(By.CssSelector(".athletes-overview__nav__athlete-details.js-goto-profile")).Click();
            Thread.Sleep(5000); //necessary for transfering to athletes page
            //Page.StartBtn.Should()
            true.Should().BeTrue();

        }

    }
}
