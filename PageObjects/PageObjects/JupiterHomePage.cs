﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.PageObjects
{
    public class JupiterHomePage
    {
        //locators
        private IWebElement ContactButton => driver.FindElement(By.Id("nav-contact"));
        private IWebElement ShopButton => driver.FindElement(By.Id("nav-shop"));

        private IWebElement CartButton => driver.FindElement(By.Id("nav-cart"));

        private IWebDriver driver;

        public JupiterHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public JupiterContactPage NavigateToContactPage()
        {
            ContactButton.Click();
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            webDriverWait.Until(driver => driver.FindElement(By.Id("header-message")));

            return new JupiterContactPage(driver);
        }

        public JupiterShopPage NavigateToShopPage()
        {
            ShopButton.Click();
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            webDriverWait.Until(driver => driver.FindElement(By.CssSelector("div.products.ng-scope")));

            return new JupiterShopPage(driver);
        }

        public JupiterCartPage NavigateToCartPage()
        {
            CartButton.Click();
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            webDriverWait.Until(driver => driver.FindElement(By.ClassName("container-fluid")));

            return new JupiterCartPage(driver);
        }
    }
}
