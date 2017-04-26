using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using Tests.Pages;
using Tests.Helpers;

namespace Tests
{
    public class FrontpageTests : TestSetup
    {
        public IWebDriver Driver;
        public Frontpage Page;

        public FrontpageTests()
        {
            Driver = OpenBrowser("chrome");
            OpenPage(BaseUrl + ConfigurationManager.AppSettings["FrontpageUrl"]);
            Page = new Frontpage(Driver);
        }

        [Test]
        [Category("Desktop")]
        [Category("DesignMatch")]
        public void ItemsLocations_Should_MatchDesign()
        {
            Page.Logo.CenteredHorizontallyScreen().Should().BeTrue();
            Page.IntroText.CenteredAllScreen().Should().BeTrue();
            Page.StartBtn.CenteredHorizontallyScreen().Should().BeTrue();
            Page.StartBtnText.CenteredHorizontallyScreen().Should().BeTrue();
            Page.NavigationLinks.First().LeftOf(Page.IntroText).Should().BeTrue();
            Page.NavigationLinks.Last().RightOf(Page.IntroText).Should().BeTrue();
            Page.StartBtnText.Text.Should().NotBeEmpty();
        }


    }
}
