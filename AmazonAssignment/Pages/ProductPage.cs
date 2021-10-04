using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AmazonAssignment.Pages
{
    public class ProductPage
    {
        //Used to intialize elements of a page class
        public ProductPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//img[@class='s-image']")]
        [CacheLookup]
        public IWebElement product;

        [FindsBy(How = How.XPath, Using = "//input[@id='add-to-wishlist-button-submit']")]
        [CacheLookup]
        public IWebElement addtowishlist;


        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'View Wish List')]")]
        [CacheLookup]
        public IWebElement viewwishlist;

        [FindsBy(How = How.LinkText, Using = "Add to Cart")]
        [CacheLookup]
        public IWebElement addtocart;

        [FindsBy(How = How.LinkText, Using = "Proceed to checkout")]
        [CacheLookup]
        public IWebElement proceedtocheckout;
    }
}
