using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AmazonAssignment.Base
{
    public class BaseClass
    {
        public static IWebDriver driver;
        [SetUp]
        public void SetUp()
        { 
                driver = new ChromeDriver();
                driver.Url = "https://www.amazon.in/";
                //Used to maximize the window
                driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            //Used to close the opened session
            driver.Quit();
        }
    }
}
