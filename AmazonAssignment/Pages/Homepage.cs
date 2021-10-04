using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonAssignment.Pages
{
    public class Homepage
    {
        //Used to intialize elements of a page class
        public Homepage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "twotabsearchtextbox")]
        [CacheLookup]
        public IWebElement searchbar;
    }
}
