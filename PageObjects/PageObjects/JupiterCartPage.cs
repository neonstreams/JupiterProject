using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        //private int GetCartTableRowValue(string productName, string valueType)
        //{
        //    IWebElement targetedRow;

        //    //var tableHeaderElement = driver.FindElement(By.TagName("thead"));
        //    //IWebElement tableheaderRow = tableHeaderElement.FindElement(By.TagName("tr"));

        //    var tableBodyElement = driver.FindElement(By.TagName("tbody")); //use table class selector instead then get tbody
        //    IList<IWebElement> tableBodyRows = tableBodyElement.FindElements(By.TagName("tr"));

        //    foreach (var row in tableBodyRows)
        //    {
        //        IList<IWebElement> tableRowDivisions = row.FindElements(By.TagName("td"));
        //        foreach (var rowDivision in tableRowDivisions)
        //        {

        //        }
        //    }
        //}


        public double GetPrice(string productName)
        {
            return 0.0;
        }

        public int GetQuantity(string productName)
        {
            return 1;
        }

        public double GetSubtotal(string productName)
        {
            return 0.0;
        }
    }
}
