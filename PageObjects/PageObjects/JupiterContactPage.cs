﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.PageObjects
{
    public class JupiterContactPage
    {
        //locators
        private IWebElement ForenameField => driver.FindElement(By.Id("forename"));
        private IWebElement EmailField => driver.FindElement(By.Id("email"));
        private IWebElement MessageField => driver.FindElement(By.Id("message"));

        private IWebElement ForenameErrorMessage; //=> driver.FindElement(By.Name("forename-err"));

        private IWebElement SubmitButton; //=> driver.FindElement(By.LinkText("Submit")); 

        private string GetErrorText(By locator)
        {
            IReadOnlyCollection<IWebElement> elements = this.driver.FindElements(locator);
            if (elements.Count == 0)
            {
                return "";
            }
            else
            {
                return elements.ElementAt(0).Text;
            }
        }

        IWebDriver driver;

        //constructor
        public JupiterContactPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //methods
        public string GetForenameErrorText()
        {
            return GetErrorText(By.Id("forename-err"));
        }

        public string GetEmailErrorText()
        {
            return GetErrorText(By.Id("email-err"));
        }

        public string GetMessageErrorText()
        {
            return GetErrorText(By.Id("message-err"));
        }

        public JupiterContactPage WriteTextToForenameField(string text)
        {
            ForenameField.SendKeys(text);

            return this;
        }

        public JupiterContactPage WriteTextToEmailField(string text)
        {
            EmailField.SendKeys(text);

            return this;
        }

        public JupiterContactPage WriteTextToMessageField(string text)
        {
            MessageField.SendKeys(text);

            return this;
        }

        public void WaitUntilSubmissionLoadingModalFinishes()
        {
            //fluent wait
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromSeconds(1)
            };
            webDriverWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("modal-header")));
        }




        //explicitly wait for Submit Button to exist in the DOM
        public JupiterContactPage SubmitForm()
        {
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            var condition = webDriverWait.Until(e => e.FindElement(By.LinkText("Submit")));

            SubmitButton = driver.FindElement(By.LinkText("Submit"));
            SubmitButton.Click();

            return this;
        }

        public bool ForenameErrorMessageIsVisible()
        {

            try
            {
                //Explicit wait code
                //WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                //var condition = webDriverWait.Until(e => e.FindElement(By.Id("forename-err")));

                if (driver.FindElement(By.Id("forename-err")).Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool EmailErrorMessageIsVisible()
        {
            try
            {
                if (driver.FindElement(By.Id("email-err")).Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool MessageErrorMessageIsVisible()
        {
            try
            {
                if (driver.FindElement(By.Id("message-err")).Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool FormSubmissionSuccessMessageIsVisible()
        {
            //Explicit wait code
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            var condition = webDriverWait.Until(e => e.FindElement(By.CssSelector("div.alert.alert-success")));

            try
            {
                if (driver.FindElement(By.CssSelector("div.alert.alert-success")).Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
