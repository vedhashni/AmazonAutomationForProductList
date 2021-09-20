using OpenQA.Selenium;
using System;

namespace AmazonAssignment.TakeScreeShot
{
    public class ScreenShot
    {
        //Used to takescreenshot of the webactions done
        public static void TakeScreenShot(IWebDriver driver)
        {
            ITakesScreenshot screenshot = driver as ITakesScreenshot;
            Screenshot screenshot1 = screenshot.GetScreenshot();
            screenshot1.SaveAsFile(@"C:\Users\vedhashni.v\source\repos\AmazonAssignment\AmazonAssignment\TakeScreeShot\AmazonTest" + DateTime.Now.ToString("HHmmss") + ".png");
        }
    }
}
