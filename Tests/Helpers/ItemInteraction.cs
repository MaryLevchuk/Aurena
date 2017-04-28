using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using Tests.Helpers;


namespace Tests.Helpers
{
    public class ItemInteraction
    {
        public string GetLinkHref(IWebElement link)
        {
            return link.GetAttribute("href");
        }
    }
}
