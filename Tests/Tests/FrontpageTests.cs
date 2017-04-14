using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using Tests.Pages;

namespace Tests
{
    public class FrontpageTests : TestSetup
    {
        public IWebDriver Driver;

        [OneTimeSetUp]
        public void StartBrowser(string browserName)
        {
            Driver = OpenBrowser("chrome");
            Frontpage page = new Frontpage();

        }

        [Test]
        public void 
    }
}
