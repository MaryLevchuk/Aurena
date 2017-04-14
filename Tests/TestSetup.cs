using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;


namespace Tests
{
    public abstract class TestSetup
    {
        public IWebDriver Driver;

        public void InitializeDriver(string driverName)
        {
            switch (driverName)
            {
                case "chrome":
                    Driver = new ChromeDriver();
                    break;
                case "firefox":
                    Driver = new FirefoxDriver();
                    break;
                case "ie":
                    Driver = new InternetExplorerDriver();
                    break;
                case "edge":
                    Driver = new EdgeDriver();
                    break;
            }
        }

        
        public IWebDriver OpenBrowser(string browser)
        {
            InitializeDriver(browser);
            Driver.Manage().Window.Maximize();
            return Driver;
        }

        public void OpenPage(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }

    }
}

