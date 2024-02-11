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

            Assert.That(jupiterContactPage.FormSubmissionSuccessMessageIsVisible(), Is.EqualTo(true));
        }

        [Test]
        public void NavigateToShopPageThenAddProductsAndVerifyPricesOnCartPage()
        {
            //navigate to shop page
            var jupiterShopPage = JupiterHomePage.NavigateToShopPage();

            //grab the products to use during Asserts
            var frogProduct =  jupiterShopPage.GetProduct("Stuffed Frog");
            var bunnyProduct = jupiterShopPage.GetProduct("Fluffy Bunny");
            var bearProduct =  jupiterShopPage.GetProduct("Valentine Bear");

            //add the products to the cart
            frogProduct.ClickBuyButton(2);
            bunnyProduct.ClickBuyButton(5);
            bearProduct.ClickBuyButton(3);

            //navigate to the cart page
            var jupiterCartPage = JupiterHomePage.NavigateToCartPage();

            //assert the prices match
            Assert.That(jupiterCartPage.GetPrice("Stuffed Frog"), Is.EqualTo(frogProduct.ProductPrice));
            Assert.That(jupiterCartPage.GetPrice("Fluffy Bunny"), Is.EqualTo(bunnyProduct.ProductPrice));
            Assert.That(jupiterCartPage.GetPrice("Valentine Bear"), Is.EqualTo(bearProduct.ProductPrice));

            //assert each subtotal equals the cart price x cart quantity
            Assert.That(jupiterCartPage.GetSubtotal("Stuffed Frog"), Is.EqualTo(jupiterCartPage.GetPrice("Stuffed Frog") * 
                                                                                jupiterCartPage.GetQuantity("Stuffed Frog")));

            Assert.That(jupiterCartPage.GetSubtotal("Fluffy Bunny"), Is.EqualTo(jupiterCartPage.GetPrice("Fluffy Bunny") * 
                                                                                jupiterCartPage.GetQuantity("Fluffy Bunny")));

            Assert.That(jupiterCartPage.GetSubtotal("Valentine Bear"), Is.EqualTo(jupiterCartPage.GetPrice("Valentine Bear") * 
                                                                                  jupiterCartPage.GetQuantity("Valentine Bear")));

            //assert the cart total equals the subtotals added together
            Assert.That(jupiterCartPage.GetCartTotal(), Is.EqualTo(jupiterCartPage.GetSubtotal("Stuffed Frog") +
                                                                   jupiterCartPage.GetSubtotal("Fluffy Bunny") +
                                                                   jupiterCartPage.GetSubtotal("Valentine Bear")));
        }
    }
}
