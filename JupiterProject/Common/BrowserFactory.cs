using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterProject.Common
{
    public static class BrowserFactory
    {
        public static IWebDriver Driver;

        public static WebDriver provideBrowser(string browserName)
        {
            if (browserName == "chrome")
            {
                Driver = new ChromeDriver();

            }
            if (browserName == "firefox")
            {
                Driver = new FirefoxDriver();
            }

            return (WebDriver)Driver;
        }
    }
}
