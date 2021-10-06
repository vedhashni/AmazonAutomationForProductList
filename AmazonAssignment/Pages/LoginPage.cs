using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AmazonAssignment.Pages
{
    public class LoginPage
    {
        //Used to intialize elements of a page class
        public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "nav-logo")]
        [CacheLookup]
        public IWebElement logo;

        //Used to find the sigin button by specifying its locator
        [FindsBy(How = How.XPath, Using = "//a[@id='nav-link-accountList']")]
        [CacheLookup]
        public IWebElement login;

        //Used to find the element email by specifying its locator
        [FindsBy(How = How.Name, Using = "email")]
        [CacheLookup]
        public IWebElement email;

        //Used to find the continue button by specifying its locator
        [FindsBy(How = How.Id, Using = "continue")]
        [CacheLookup]
        public IWebElement continuebtn;

        //Used to find the element password by specifying its locator
        [FindsBy(How = How.Id, Using = "ap_password")]
        [CacheLookup]
        public IWebElement password;

        //Used to find the signin button by specifying its locator
        [FindsBy(How = How.Id, Using = "signInSubmit")]
        [CacheLookup]
        public IWebElement signin;

        [FindsBy(How = How.XPath, Using = "//*[text()='Hello, Velmurugan']")]
        [CacheLookup]
        public IWebElement message;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'To better protect your account, please re-enter your password and then enter the characters as they are shown in the image below.')]")]
        [CacheLookup]
        public IWebElement alertmessage;
    }
}
