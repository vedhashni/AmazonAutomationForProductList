using AmazonAssignment.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonAssignment.WebPageActions
{
    public class ProductPage
    {
        public static ProductPageData data;
        public static void ParticularProduct(IWebDriver driver)
        {
            data = new ProductPageData(driver);
            data.product.Click();
            System.Threading.Thread.Sleep(1000);
        }
    }
}
