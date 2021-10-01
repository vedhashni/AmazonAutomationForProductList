using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AmazonAssignment.Data
{
    public class ProductPageData
    {
        //Used to intialize elements of a page class
        public ProductPageData(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//img[@class='s-image']")]
        [CacheLookup]
        public IWebElement product;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Add to Wish List')]")]
        [CacheLookup]
        public IWebElement addtowishlist;

        [FindsBy(How = How.XPath, Using = "//input[@id='add-to-wishlist-button-submit']")]
        [CacheLookup]
        public IWebElement againaddtowishlist;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'View Wish List')]")]
        [CacheLookup]
        public IWebElement viewwishlist;

        [FindsBy(How = How.LinkText, Using = "Add to Cart")]
        [CacheLookup]
        public IWebElement addtocart;

        [FindsBy(How = How.LinkText, Using = "Proceed to checkout")]
        [CacheLookup]
        public IWebElement proceedtocheckout;

        [FindsBy(How = How.XPath, Using = "//body/div[@id='a-page']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[2]/div[1]/div[2]/form[1]/div[1]/div[1]/div[1]/fieldset[2]/div[1]/span[1]/div[1]/label[1]/input[1]")]
        [CacheLookup]
        public IWebElement selectaddress;

        [FindsBy(How = How.XPath, Using = "//body/div[@id='a-page']/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/span[1]/span[1]/span[1]/span[1]/input[1]")]
        [CacheLookup]
        public IWebElement usethisaddressbtn;

        [FindsBy(How = How.XPath, Using = "//body[1]/div[5]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[4]/div[1]/div[3]/div[1]/div[2]/div[1]/div[1]/div[3]/div[1]/form[1]/div[1]/div[1]/div[1]/div[2]/div[6]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/label[1]/input[1]")]
        [CacheLookup]
        public IWebElement selectmodeofpayment;

        [FindsBy(How = How.XPath, Using = "//span[@id='orderSummaryPrimaryActionBtn']")]
        [CacheLookup]
        public IWebElement usethispaymentbtn;

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

    }
}
