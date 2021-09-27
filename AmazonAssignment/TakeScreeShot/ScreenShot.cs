using OpenQA.Selenium;


namespace AmazonAssignment.TakeScreeShot
{
    public class ScreenShot:Base.BaseClass
    {
        //Used to takescreenshot of the webactions done
        public void TakeScreenShot()
        {
            ITakesScreenshot screenshot = driver as ITakesScreenshot;
            Screenshot screenshot1 = screenshot.GetScreenshot();
            screenshot1.SaveAsFile(@"C:\Users\vedhashni.v\source\repos\AmazonAssignment\AmazonAssignment\TakeScreeShot\AmazonTest.png");
        }
    }
}
