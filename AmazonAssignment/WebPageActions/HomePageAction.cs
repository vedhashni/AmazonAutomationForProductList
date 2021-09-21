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
            System.Threading.Thread.Sleep(15000);
            ListOfProductsBrandName(driver);
            
        }

        //Used to retrive brand's name
        public static void ListOfProductsBrandName(IWebDriver driver)
        {
            //Getting the list of product brand's name by using class
            IList<IWebElement> productbrandname = driver.FindElements(By.ClassName("s-line-clamp-1"));
            foreach (IWebElement currentproductbrandname in productbrandname)
            {
                //getting the brandname of each current product 
                //Text is used to get the name of innerelements in webpages
                    string brandname = currentproductbrandname.Text;
                    Console.WriteLine(brandname);
            }
            //Calling this method to print the ratings of each product 
                RatingsOfEachBrandedProduct(driver);
        }

        //Used to retrive ratings of each product
        public static void RatingsOfEachBrandedProduct(IWebDriver driver)
        {
            //getting the ratings of each product by using aria-label 
            IList<IWebElement> productrating = driver.FindElements(By.CssSelector("span[aria-label]"));
            foreach (IWebElement currentproductrating in productrating)
            {
                //rating of each product is displayed
                string rating = currentproductrating.Text;
                Console.WriteLine(rating);
            }
        }
    }
}
