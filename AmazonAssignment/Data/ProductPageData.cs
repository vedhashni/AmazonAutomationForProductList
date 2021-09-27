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

        [FindsBy(How = How.XPath, Using = "//input[@id='add-to-wishlist-button-submit']")]
        [CacheLookup]
        public IWebElement addtowishlist;

        [FindsBy(How = How.XPath, Using = "//span[@class='w-button-text']")]
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

        [FindsBy(How = How.Name, Using = "ppw-instrumentRowSelection")]
        [CacheLookup]
        public IWebElement selectmodeofpayment;

    }
}
