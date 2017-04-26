using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
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
        private IWebDriver _driver;
        public string BaseUrl = ConfigurationManager.AppSettings["Test"];

        public void InitializeDriver(string driverName)
        {
            switch (driverName)
            {
                case "chrome":
                    _driver = new ChromeDriver();
                    break;
                case "firefox":
                    _driver = new FirefoxDriver();
                    break;
                case "ie":
                    _driver = new InternetExplorerDriver();
                    break;
                case "edge":
                    _driver = new EdgeDriver();
                    break;
            }
        }
        
        public IWebDriver OpenBrowser(string browser)
        {
            InitializeDriver(browser);
            _driver.Manage().Window.Maximize();
            return _driver;
        }

        public void OpenPage(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public int GetScreenHeight()
        {
            return _driver.Manage().Window.Size.Height;
        }

        public int GetScreenWidth()
        {
            return _driver.Manage().Window.Size.Width;
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
        }

    }
}

