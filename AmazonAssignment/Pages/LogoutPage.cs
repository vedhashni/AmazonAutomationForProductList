using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonAssignment.Pages
{
    public class LogoutPage
    {
        //Used to intialize elements of a page class
        public LogoutPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@id='nav-link-accountList']")]
        [CacheLookup]
        public IWebElement accountarrow;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Sign Out')]")]
        [CacheLookup]
        public IWebElement signout;

        [FindsBy(How = How.Id, Using = "ap_email")]
        [CacheLookup]
        public IWebElement email;

        [FindsBy(How = How.Id, Using = "continue")]
        [CacheLookup]
        public IWebElement Continuebtn;
    }
}
