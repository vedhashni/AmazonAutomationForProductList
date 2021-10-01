using NUnit.Framework;
using AmazonAssignment.Data;
using AmazonAssignment.TakeScreeShot;

namespace AmazonAssignment.WebPageActions
{
    public class LoginPageAction:Base.BaseClass
    {
        public static LoginPage sign;
        public static ScreenShot shot;

        //Used to check title given and retived are same
        public static void TitleAfterLaunching()
        {
            string title1 = "Online Shopping site in India: Shop Online for Mobiles, Books, Watches, Shoes and More - Amazon.in";
            string title = driver.Title;
            //AreEqual is used to compare expected and actual result
            Assert.AreEqual(title1, title);
        }

        //Here we are reading the data from excel
        public void ReadDataFromExcel()
        {
            try
            {
                excel = new ExcelOperation();
                excel.PopulateFromExcel(@"C:\Users\vedhashni.v\source\repos\AmazonAssignment\AmazonAssignment\Data\AmazonSignInData.xlsx");
            }
            catch
            {
                throw new CustomException(CustomException.ExceptionType.FileNotFoundException, "File is not found in the given path");
            }
        }

        //Used for implementing login operations
        public void LoginIntoAmazon()
        {
            shot = new ScreenShot();
            sign = new LoginPage(driver);

            shot.TakeScreenShot();
            sign.login.Click();
            System.Threading.Thread.Sleep(1000);
            shot.TakeScreenShot();
            //By invoking the readdate method values in table is retrived
            sign.email.SendKeys(excel.ReadData(1, "Email"));
            //shot.TakeScreenShot();
            //is used to wait in a particular page before taking another action
            System.Threading.Thread.Sleep(1000);
            //Here we click continue button for further process
            sign.continuebtn.Click();
            //is used to wait in a particular page before taking another action
            System.Threading.Thread.Sleep(1000);
            //By invoking the readdate method values in table is retrived
            sign.password.SendKeys(excel.ReadData(1, "Password"));
            //ScreenShot.TakeScreenShot(driver);
            System.Threading.Thread.Sleep(1000);
            sign.signin.Click();
            shot.TakeScreenShot();
            //ScreenShot.TakeScreenShot(driver);
            System.Threading.Thread.Sleep(1000);
            //Here we call Searchproductsinamazonafterlogin method for searching the product
            string expectedtitle = "https://www.amazon.in/?ref_=nav_ya_signin&";
            string actualtitle = driver.Url;
            Assert.AreEqual(expectedtitle, actualtitle);

        }
    }
}
