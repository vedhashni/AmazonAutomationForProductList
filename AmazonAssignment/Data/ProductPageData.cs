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
    }
}
