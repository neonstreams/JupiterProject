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

        //Returns a list of <td> elements, for the row that matches the product name passed in.
        private IList<IWebElement> GetCartTableRow(string productName)
        {
            IWebElement productRow = null;
            var tableElement = driver.FindElement(By.CssSelector("table[class='table table-striped cart-items']"));
            var tableBodyElement = tableElement.FindElement(By.TagName("tbody"));
            var tableBodyRows = tableBodyElement.FindElements(By.CssSelector("tr[class='cart-item ng-scope']"));

            foreach (var row in tableBodyRows)
            {
                var firstTdElement = row.FindElements(By.TagName("td")).First();
                if (firstTdElement.Text == productName)
                {
                    productRow = row;
                    break;
                }
            }
            return productRow.FindElements(By.TagName("td"));
        }

        //Returns the index of a table column based on the column's title - e.g. "Item", "Quantity", "Subtotal" etc.
        private int GetIndexOfColumnName(string columnName)
        {
            var tableHeaderElement = driver.FindElement(By.TagName("thead"));
            var thList = tableHeaderElement.FindElements(By.TagName("th"));
            return thList.IndexOf(thList.First(p => p.Text == columnName));
        }

        public double GetCartTotal()
        {
            var tableFooterElement = driver.FindElement(By.TagName("tfoot"));
            var totalElement = tableFooterElement.FindElement(By.CssSelector("strong[class='total ng-binding']"));
            return Double.Parse(totalElement.Text.Substring(6));
        }

        public double GetPrice(string productName)
        {
            var trimmedPrice = GetCartTableRow(productName)
                                .ElementAt(GetIndexOfColumnName("Price"))
                                    .Text.Substring(1);
            return Double.Parse(trimmedPrice);
        }

        public int GetQuantity(string productName)
        {
            var quantityElement = GetCartTableRow(productName)
                                    .ElementAt(GetIndexOfColumnName("Quantity"))
                                        .FindElement(By.TagName("input"));
            return Int32.Parse(quantityElement.GetDomAttribute("value"));
        }

        public double GetSubtotal(string productName)
        {
            var trimmedSubtotal = GetCartTableRow(productName)
                                    .ElementAt(GetIndexOfColumnName("Subtotal"))
                                        .Text.Substring(1);
            return Double.Parse(trimmedSubtotal);
        }
    }
}
