using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PageObjects.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterProject.Common
{
    public class TestBase
    {
        protected IWebDriver? Driver { get; private set; }

        protected JupiterHomePage? JupiterHomePage { get; private set; }

        [SetUp]
        public void Setup()
        {
            var browser = Environment.GetEnvironmentVariable("BROWSER");

            //default to DriverChrome if an empty string
            if (String.IsNullOrEmpty(browser))
            {
                browser = "chrome";
            };

            Driver = BrowserFactory.provideBrowser(browser);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/");

            WebDriverWait webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var condition = webDriverWait.Until(e => e.Title == "Jupiter Toys");

            JupiterHomePage = new JupiterHomePage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
