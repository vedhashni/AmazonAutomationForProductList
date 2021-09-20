using AmazonAssignment.TakeScreeShot;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AmazonAssignment.WebPageActions
{
    public class HomePageAction
    {
        //Here we use Searchproductsinamazonafterlogin method for searching the product
        public static void SearchProductsInAmazonAfterLogin(IWebDriver driver)
        {
            ScreenShot.TakeScreenShot(driver);
            //Here search bar element is finded
            IWebElement element = driver.FindElement(By.Id("twotabsearchtextbox"));
            //By using this search bar is clicked
            element.SendKeys(Keys.Control + "a");
            ScreenShot.TakeScreenShot(driver);
            System.Threading.Thread.Sleep(500);
            //Value is sent to find specific product
            element.SendKeys("palazzo kurta");
            ScreenShot.TakeScreenShot(driver);
            System.Threading.Thread.Sleep(500);
            //By keys class arrowup used to select the value listed down the search bar
            element.SendKeys(Keys.ArrowUp);
            System.Threading.Thread.Sleep(500);
            //By keys class arrowdown used to select the value listed down the search bar
            element.SendKeys(Keys.ArrowDown);
            System.Threading.Thread.Sleep(500);
            element.SendKeys(Keys.ArrowDown);
            System.Threading.Thread.Sleep(500);
            ScreenShot.TakeScreenShot(driver);
            //By using this particular product is searched by clicking the enter key instead search icon
            element.SendKeys(Keys.Enter);
            ScreenShot.TakeScreenShot(driver);
            System.Threading.Thread.Sleep(10000);
            ListOfProductsListed(driver);
        }

        public static void ListOfProductsListed(IWebDriver driver)
        {
            IList<IWebElement> productdetails = driver.FindElements(By.ClassName("s-line-clamp-1"));
            foreach(IWebElement currentproductdetails in productdetails)
            {
                string productname = currentproductdetails.Text;
                Console.WriteLine(productname);
            }
        }
    }
}
