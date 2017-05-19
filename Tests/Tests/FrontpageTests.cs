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
        [Category("Frontpage")]
        public void PageTitle_ShouldBe_Aurena()
        {
            Page.Name.Should().Contain("Aurena");
        }

        [Test]
        [Category("Frontpage")]
        public void Logo_ShouldHave_ProperLink()
        {
            Item.GetLinkHref(Page.Logo).Should().Contain("#");
        }

        [Test]
        [Category("Frontpage")]
        public void AboutPageLink_ShouldHave_ProperLink()
        {
            Item.GetLinkHref(Page.NavigationLinks.First()).Should().Contain(BaseUrl + ConfigurationManager.AppSettings["AboutPageUrl"]);
        }

        [Test]
        [Category("Frontpage")]
        public void SignUpPageLink_ShouldHave_ProperLink()
        {
            Item.GetLinkHref(Page.NavigationLinks.Last()).Should().Contain(BaseUrl + ConfigurationManager.AppSettings["SignUpPageUrl"]);
        }

        [Test]
        [Category("Frontpage")]
        public void TransferToAthletesPage_ShouldBe()
        {
            Page.Click_AndHold(Page.StartBtn);
            Page.NavDots.Displayed.Should().BeTrue();
        }

    }
}
