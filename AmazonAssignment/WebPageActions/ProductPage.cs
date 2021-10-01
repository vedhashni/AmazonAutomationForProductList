using AmazonAssignment.Data;
using AmazonAssignment.TakeScreeShot;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AmazonAssignment.WebPageActions
{
    public class ProductPage:Base.BaseClass
    {
        public static ProductPageData data;
        public static HomePageAction homePage;
        public static ScreenShot shot;
        public static LoginPageAction login;
        public static ExcelOperation excel1;

        public void AddParticularProductToCart()
        {
            shot = new ScreenShot();
            homePage = new HomePageAction();
            data = new ProductPageData(driver);
            login = new LoginPageAction();
            excel1 = new ExcelOperation();
            homePage.SearchProductsInAmazonAfterLogin();
            data.product.Click();
            var newTabHandle = driver.WindowHandles[1];
            Assert.IsTrue(!string.IsNullOrEmpty(newTabHandle));
            driver.SwitchTo().Window(newTabHandle);
            System.Threading.Thread.Sleep(2000);
            //SelectElement element = new SelectElement(driver.FindElement(By.Name("birthday_day")));
            //shot.TakeScreenShot();
            data.addtowishlist.Click();
            System.Threading.Thread.Sleep(2000);
            login.ReadDataFromExcel();
            //System.Threading.Thread.Sleep(1000);
            data.email.SendKeys(excel1.ReadData(1, "Email"));
            data.continuebtn.Click();
            data.password.SendKeys(excel1.ReadData(1, "Password"));
            data.signin.Click();
            System.Threading.Thread.Sleep(2000);
            data.againaddtowishlist.Click();
            System.Threading.Thread.Sleep(1000);
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
            System.Threading.Thread.Sleep(1000);
            data.usethispaymentbtn.Click();

        }
    }
}
