using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.PageObjects
{
    public class JupiterShopPage
    {
        private IWebDriver driver;

        public JupiterShopPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public Product GetProduct(string productName)
        {
            var products = GetProductsList();
            Product p = products.First(p => p.ProductName == productName);
            return p;
        }
        private List<Product> GetProductsList()
        {
            var products = new List<Product>();
            var productsDivElement = driver.FindElement(By.CssSelector("div.products.ng-scope"));
            IList<IWebElement> productsElementsList = productsDivElement.FindElements(By.TagName("li"));

            foreach (IWebElement productElement in productsElementsList)
            {
                products.Add(BuildProductFromProductListElement(productElement));
            }
            return products;
        }

        private Product BuildProductFromProductListElement(IWebElement productListElement)
        {
            var headerElement = productListElement.FindElement(By.TagName("h4"));
            var spanElement = productListElement.FindElement(By.TagName("p")).FindElement(By.TagName("span"));
            var buttonElement = productListElement.FindElement(By.TagName("p")).FindElement(By.TagName("a"));

            var price = Double.Parse(spanElement.Text.Substring(1));
            var name = headerElement.Text;

            Product product = new Product(name, price, buttonElement);
            return product;
        }


    }
}
