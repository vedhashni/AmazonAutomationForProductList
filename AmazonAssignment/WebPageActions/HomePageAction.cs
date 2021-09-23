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
            //ScreenShot.TakeScreenShot(driver);
            //Here search bar element is finded
            IWebElement element = driver.FindElement(By.Id("twotabsearchtextbox"));
            //By using this search bar is clicked
            element.SendKeys(Keys.Control + "a");
            //ScreenShot.TakeScreenShot(driver);
            System.Threading.Thread.Sleep(500);
            //Value is sent to find specific product
            element.SendKeys("palazzo kurta");
            //ScreenShot.TakeScreenShot(driver);
            System.Threading.Thread.Sleep(500);
            //By keys class arrowup used to select the value listed down the search bar
            element.SendKeys(Keys.ArrowUp);
            System.Threading.Thread.Sleep(500);
            //By keys class arrowdown used to select the value listed down the search bar
            element.SendKeys(Keys.ArrowDown);
            System.Threading.Thread.Sleep(500);
            element.SendKeys(Keys.ArrowDown);
            System.Threading.Thread.Sleep(500);
            //ScreenShot.TakeScreenShot(driver);
            //By using this particular product is searched by clicking the enter key instead search icon
            element.SendKeys(Keys.Enter);
            //ScreenShot.TakeScreenShot(driver);
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
                    Console.WriteLine("PRODUCT NAME :"+brandname);
            }
            //Calling this method to print the ratings of each product 
            RatingsOfEachBrandedProduct(driver);
        }

        //Used to retrive ratings of each product
        public static void RatingsOfEachBrandedProduct(IWebDriver driver)
        {

            IList<string> productRating = new List<string>();
            foreach (var r in driver.FindElements(By.XPath("//*[@class='a-popover-trigger a-declarative']")))
            {
                r.Click();
                System.Threading.Thread.Sleep(5000);
                foreach (var rating in driver.FindElements(By.CssSelector("span[class='a-size-medium a-color-base a-text-beside-button a-text-bold']")))
                {
                    if (!string.IsNullOrEmpty(rating.Text))
                    {
                        productRating.Add(rating.Text);
                        Console.WriteLine("Product Rating {0}", rating.Text);
                    }
                    else
                    {
                        productRating.Remove(rating.Text);
                    }
                }
            }
            PriceOfProduct(driver);
        }

        public static void PriceOfProduct(IWebDriver driver)
        {
            IList<IWebElement> priceofproduct = driver.FindElements(By.ClassName("a-price"));
            foreach(IWebElement price in priceofproduct)
            {
                string productprice = price.Text;
                Console.WriteLine("Price :" + productprice);
            }
        }
    }
}
