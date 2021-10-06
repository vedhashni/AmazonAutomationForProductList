using log4net;
using log4net.Config;
using log4net.Repository;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace AmazonAssignment.Base
{
    public class BaseClass
    {
        public static IWebDriver driver;
        //Get Logger for fully qualified name for type of 'AlertTests' class
        public static readonly ILog log = LogManager.GetLogger(typeof(AmazonTest));

        //Get the default ILoggingRepository
        public static readonly ILoggerRepository repository = LogManager.GetRepository(Assembly.GetCallingAssembly());
        
        [SetUp]
        public void BrowserTest()
        {
            //BasicConfigurator.Configure();
            // Valid XML file with Log4Net Configurations
            var fileInfo = new FileInfo(@"log4net.config");

            // Configure default logging repository with Log4Net configurations
            XmlConfigurator.Configure(repository, fileInfo);
            try
            {
                driver = new ChromeDriver();
                log.Info("Configured");
                driver.Url = "https://www.amazon.in/";
                log.Debug("navigating to url");
                //Used to maximize the window
                driver.Manage().Window.Maximize();
                log.Info("Window is maximized");
            }
            catch
            {
                throw new CustomException(CustomException.ExceptionType.NoSuchSessionException, "chrome session is not created");
            }
        }

        [TearDown]
        public void TearDown()
        {
            //Used to close the opened session
            driver.Quit();
        }

        public void TakeScreenShot()
        {
            ITakesScreenshot screenshot = driver as ITakesScreenshot;
            Screenshot screenshot1 = screenshot.GetScreenshot();
            screenshot1.SaveAsFile(@"C:\Users\vedhashni.v\source\repos\AmazonAssignment\AmazonAssignment\TakeScreeShot\AmazonTest.png");
        }
    }
}
