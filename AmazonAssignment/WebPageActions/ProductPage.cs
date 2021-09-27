using AmazonAssignment.Data;
using AmazonAssignment.TakeScreeShot;
using NUnit.Framework;

namespace AmazonAssignment.WebPageActions
{
    public class ProductPage:Base.BaseClass
    {
        public static ProductPageData data;
        public static HomePageAction homePage;
        public static ScreenShot shot;
        public void AddParticularProductToCart()
        {
            homePage = new HomePageAction();
            shot = new ScreenShot();
            homePage.SearchProductsInAmazonAfterLogin();
            data = new ProductPageData(driver);
            try
            {
                data.product.Click();
                var newTabHandle = driver.WindowHandles[1];
                Assert.IsTrue(!string.IsNullOrEmpty(newTabHandle));
                driver.SwitchTo().Window(newTabHandle);
                System.Threading.Thread.Sleep(2000);
                shot.TakeScreenShot();
                data.addtowishlist.Click();
                System.Threading.Thread.Sleep(2000);
                data.viewwishlist.Click();
                string viewpage = "https://www.amazon.in/gp/registry/wishlist/2U18WJG4AUH86/ref=cm_wl_huc_view";
                string actualviewpage = driver.Url;
                Assert.AreEqual(viewpage, actualviewpage);
                System.Threading.Thread.Sleep(2000);
                data.addtocart.Click();
                System.Threading.Thread.Sleep(2000);
                data.proceedtocheckout.Click();
                string expected = "Amazon.in Checkout";
                string actual = driver.Title;
                Assert.AreEqual(expected, actual);
                System.Threading.Thread.Sleep(2000);
                data.selectaddress.Click();
                System.Threading.Thread.Sleep(10000);
                data.usethisaddressbtn.Click();
                System.Threading.Thread.Sleep(8000);
                data.selectmodeofpayment.Click();
                System.Threading.Thread.Sleep(10000);
            }
            catch
            {
                throw new CustomException(CustomException.ExceptionType.NoSuchWindowException, "Next window is not opened");
            }
        }
    }
}
