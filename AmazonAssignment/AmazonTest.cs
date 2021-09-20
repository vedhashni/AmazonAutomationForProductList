using NUnit.Framework;

namespace AmazonAssignment
{
    public class AmazonTest:Base.BaseClass
    {
        //Used to test the tile after launcing the browser
        [Test, Order(0)]
        public void TestMethodTitleAfterLaunching()
        {
            WebPageActions.LoginPageAction.TitleAfterLaunching(driver);
        }

        //Used to read the data from excel
        //Used to login into Amazon with credentials given in the excel
        [Test, Order(1)]
        public void TestMethodForLoginIntoAmazon()
        {
            WebPageActions.LoginPageAction.ReadDataFromExcel(driver);
            WebPageActions.LoginPageAction.LoginIntoAmazon(driver);
        }
    }
}