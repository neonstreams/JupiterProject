using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.PageObjects
{
    public class JupiterCartPage
    {
        private IWebDriver driver;

        //constructor
        public JupiterCartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement GetCartTableRow(string productName)
        {
            IWebElement productRow = null;


            //IWebElement tableDiv = driver.FindElement(By.ClassName("container-fluid"));

            //IWebElement innerTableDiv = tableDiv.FindElement(By.ClassName("ng-scope"));

            IWebElement tableBodyElement = driver.FindElement(By.TagName("tbody"));
            
            IList<IWebElement> tableBodyRows = tableBodyElement.FindElements(By.TagName("tr"));

            foreach (var row in tableBodyRows)
            {
                var imgElement = row.FindElement(By.TagName("img"));
                if (imgElement.Text == productName)
                {
                    productRow = row;
                    break;
                }
            }
            return productRow;
        }

        private int GetIndexOfColumnName(string columnName)
        {
            var tableHeaderElement = driver.FindElement(By.TagName("thead"));
            var thList = tableHeaderElement.FindElements(By.TagName("th"));
            return thList.IndexOf(thList.First(p => p.Text == columnName));
        }

        public double GetPrice(string productName)
        {
            IList<IWebElement> tdList =
                GetCartTableRow(productName)
                .FindElements(By.TagName("td"));

            var trimmedPrice = tdList.ElementAt(GetIndexOfColumnName("Price")).Text.Substring(1);
            return Double.Parse(trimmedPrice);
        }

        public int GetQuantity(string productName)
        {
            IList<IWebElement> tdList =
               GetCartTableRow(productName)
               .FindElements(By.TagName("td"));

            var quantityElement = tdList.ElementAt(GetIndexOfColumnName("Quanity")).FindElement(By.TagName("input"));
            var quantity = quantityElement.GetDomAttribute("value");
            return Int32.Parse(quantity);
        }

        public double GetSubtotal(string productName)
        {
            IList<IWebElement> tdList =
               GetCartTableRow(productName)
               .FindElements(By.TagName("td"));

            var trimmedSubtotal = tdList.ElementAt(GetIndexOfColumnName("Subtotal")).Text.Substring(1);
            return Double.Parse(trimmedSubtotal);
        }
    }
}
