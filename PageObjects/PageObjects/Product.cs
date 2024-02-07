using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.PageObjects
{
    public class Product
    {
        public string ProductName { get; private set; }
        public double ProductPrice { get; private set; }

        private IWebElement BuyButton { get; set; }

        public Product(string name, double price, IWebElement buyButton)
        {
            ProductName = name;
            ProductPrice = price;
            BuyButton = buyButton;
        }

        public void ClickBuyButton(int timesToClick)
        {
            for (int i = 0; i < timesToClick; i++)
            {
                BuyButton.Click();
            }
        }
    }
}
