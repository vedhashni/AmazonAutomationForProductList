using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AmazonAssignment.Pages
{
    public class SignUpPage
    {
        //Used to intialize elements of a page class
        public SignUpPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Used to find the sigup by using partial link text
        [FindsBy(How = How.PartialLinkText, Using = "Start here")]
        [CacheLookup]
        public IWebElement signup;

        //Used to find name by using its locator
        [FindsBy(How = How.Name, Using = "customerName")]
        [CacheLookup]
        public IWebElement name;

        //Used to find number by using its locator
        [FindsBy(How = How.Id, Using = "ap_phone_number")]
        [CacheLookup]
        public IWebElement mobilenumber;

        //Used to find email by using its locator
        [FindsBy(How = How.Id, Using = "ap_email")]
        [CacheLookup]
        public IWebElement email;

        //Used to find password by using its locator
        [FindsBy(How = How.Name, Using = "password")]
        [CacheLookup]
        public IWebElement password;

        //Used to find continue button by using its locator
        [FindsBy(How = How.Id, Using = "auth-continue")]
        [CacheLookup]
        public IWebElement continuebtn;

        //Used to find new account button by using its locator
        [FindsBy(How = How.Id, Using = "auth-verify-button")]
        [CacheLookup]
        public IWebElement newaccountbtn;
    }

}
