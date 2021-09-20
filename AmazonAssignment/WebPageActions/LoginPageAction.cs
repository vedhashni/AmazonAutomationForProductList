using OpenQA.Selenium;
using NUnit.Framework;
using AmazonAssignment.Data;
using AmazonAssignment.TakeScreeShot;

namespace AmazonAssignment.WebPageActions
{
    public class LoginPageAction
    {
        public static LoginPage sign;
        public static ExcelOperation excel;

        //Used to check title given and retived are same
        public static void TitleAfterLaunching(IWebDriver driver)
        {
            string title1 = "Online Shopping site in India: Shop Online for Mobiles, Books, Watches, Shoes and More - Amazon.in";
            string title = driver.Title;
            //AreEqual is used to compare expected and actual result
            Assert.AreEqual(title1, title);
        }

        //Here we are reading the data from excel
        public static void ReadDataFromExcel(IWebDriver driver)
        {
            excel = new ExcelOperation();
            excel.PopulateFromExcel(@"C:\Users\vedhashni.v\source\repos\AmazonAssignment\AmazonAssignment\Data\AmazonSignInData.xlsx");
        }

        //Used for implementing login operations
        public static void LoginIntoAmazon(IWebDriver driver)
        {
            excel = new ExcelOperation();
            sign = new LoginPage(driver);
            ScreenShot.TakeScreenShot(driver);
            sign.login.Click();
            System.Threading.Thread.Sleep(1000);
            ScreenShot.TakeScreenShot(driver);
            //By invoking the readdate method values in table is retrived
            sign.email.SendKeys(excel.ReadData(1, "Email"));
            ScreenShot.TakeScreenShot(driver);
            //is used to wait in a particular page before taking another action
            System.Threading.Thread.Sleep(1000);
            //Here we click continue button for further process
            sign.continuebtn.Click();
            //is used to wait in a particular page before taking another action
            System.Threading.Thread.Sleep(1000);
            //By invoking the readdate method values in table is retrived
            sign.password.SendKeys(excel.ReadData(1, "Password"));
            ScreenShot.TakeScreenShot(driver);
            System.Threading.Thread.Sleep(1000);
            sign.signin.Click();
            ScreenShot.TakeScreenShot(driver);
            System.Threading.Thread.Sleep(10000);
            //Here we call Searchproductsinamazonafterlogin method for searching the product
            HomePageAction.SearchProductsInAmazonAfterLogin(driver);
        }
    }
}
