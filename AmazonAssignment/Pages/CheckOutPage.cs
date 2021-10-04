using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AmazonAssignment.Pages
{
    public class CheckOutPage
    {
        //Used to intialize elements of a page class
        public CheckOutPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'Checkout')]")]
        [CacheLookup]
        public IWebElement checkoutpagediplayed;

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

        [FindsBy(How = How.XPath, Using = "//body/div[@id='a-page']/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/span[1]/span[1]/input[1]")]
        [CacheLookup]
        public IWebElement placeorderbtn;
    }
}
