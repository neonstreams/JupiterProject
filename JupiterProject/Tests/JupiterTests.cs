using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JupiterProject.Common;
using PageObjects.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace JupiterProject.Tests
{
    public class JupiterTests : TestBase
    {
        [Test]
        public void NavigateToContactPageAndVerifyEmptyFieldErrorMessagesDisplayAndDisappear()
        {
            //var expectedForenameErrorMessage = "Forename is required";
            var jupiterContactPage = JupiterHomePage.NavigateToContactPage();

            //assert that error message is not displayed
            Assert.That(jupiterContactPage.GetForenameErrorText, Is.EqualTo(""));
            Assert.That(jupiterContactPage.GetEmailErrorText, Is.EqualTo(""));
            Assert.That(jupiterContactPage.GetMessageErrorText, Is.EqualTo(""));

            //click on submit form button for contact form
            jupiterContactPage.SubmitForm();

            //assert that error messages display
            Assert.That(jupiterContactPage.GetForenameErrorText, Is.EqualTo("Forename is required"));
            Assert.That(jupiterContactPage.GetEmailErrorText, Is.EqualTo("Email is required"));
            Assert.That(jupiterContactPage.GetMessageErrorText, Is.EqualTo("Message is required"));

            //input text into fields
            jupiterContactPage.WriteTextToForenameField("hello");
            jupiterContactPage.WriteTextToEmailField("hello@goodbye.com");
            jupiterContactPage.WriteTextToMessageField("this is a message");

            //assert that error messages don't display
            Assert.That(jupiterContactPage.GetForenameErrorText, Is.EqualTo(""));
            Assert.That(jupiterContactPage.GetEmailErrorText, Is.EqualTo(""));
            Assert.That(jupiterContactPage.GetMessageErrorText, Is.EqualTo(""));
        }

        [Test]
        public void NavigateToContactPageAndVerifyFormSubmissionMessage()
        {
            var jupiterContactPage = JupiterHomePage.NavigateToContactPage();

            //input text into fields
            jupiterContactPage.WriteTextToForenameField("hello");
            jupiterContactPage.WriteTextToEmailField("hello@goodbye.com");
            jupiterContactPage.WriteTextToMessageField("this is a message");

            //click on submit form button for contact form
            jupiterContactPage.SubmitForm();
            jupiterContactPage.WaitUntilSubmissionLoadingModalFinishes();

            var expectedSubmissionFormSuccessMessageVisible = true;
            var actualSubmissionFormSuccessMessageVisible = jupiterContactPage.FormSubmissionSuccessMessageIsVisible();

            Assert.That(actualSubmissionFormSuccessMessageVisible, Is.EqualTo(expectedSubmissionFormSuccessMessageVisible));
        }

        [Test]
        public void NavigateToShopPageThenAddProductsAndVerifyTotalsOnCartPage()
        {
            //navigate to shop page
            var jupiterShopPage = JupiterHomePage.NavigateToShopPage();

            //add the products to the cart - use generic method, test case should be super readable
            jupiterShopPage.GetProduct("Stuffed Frog").ClickBuyButton(2);
            jupiterShopPage.GetProduct("Fluffy Bunny").ClickBuyButton(5);
            jupiterShopPage.GetProduct("Valentine Bear").ClickBuyButton(3);

            //navigate to the cart page
            //var jupiterCartPage = JupiterHomePage.NavigateToCartPage();


        }
    }
}
