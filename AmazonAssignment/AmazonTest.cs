/*summary : Amazon Automation of product list display
  Author: Vedhashni V
  Date  : 11-09-21
*/


using AmazonAssignment.Email;
using AmazonAssignment.NegativeTestCase;
using AmazonAssignment.TakeScreeShot;
using AmazonAssignment.WebPageActions;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AmazonAssignment
{
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    [Parallelizable(ParallelScope.Fixtures)]

    public class AmazonTest:Base.BaseClass
    {
        public AmazonTest(string browser) : base(browser)
        {

        }

        public static LoginPageAction login;
        public static HomePageAction homePage;
        public static ProductPage product;
        public static ScreenShot shot;
        public static InvalidLoginPageAction invalidLogin;
        public static EmailClass email;
        ExtentReports report = Report.report();
        ExtentTest test;


        //Used to read the data from excel
        //Used to login into Amazon with credentials given in the excel
        [Test, Order(0)]
        public void TestMethodForLoginIntoAmazon()
        {
            test = report.CreateTest("AmazonTests");
            test.Log(Status.Info, "Amazon Automation");
            login = new LoginPageAction();
            shot = new ScreenShot();
            login.ReadDataFromExcel();
            login.LoginIntoAmazon();
            shot.TakeScreenShot();
            System.Threading.Thread.Sleep(200);
            test.Info("ScreenShot", MediaEntityBuilder.CreateScreenCaptureFromPath(@"C:\Users\vedhashni.v\source\repos\AmazonAssignment\AmazonAssignment\TakeScreeShot\AmazonTest.png").Build());
            //test.Info("Details", MediaEntityBuilder.CreateScreenCaptureFromPath(@"C:\Users\vedhashni.v\source\repos\ReportGenerationForAmazon\ReportGenerationForAmazon\TestScreenShots\AmazonTest.png").Build());
            test.Log(Status.Pass, "TestCases Passed");
            report.Flush();
        }

        //Used to Search the product
        [Test, Order(1)]
        public void TestMethodForSearchProduct()
        {
            homePage = new HomePageAction();
            homePage.SearchProductsInAmazonAfterLogin();
            homePage.ListOfProductsBrandName();
            homePage.PriceOfProduct();
        }

        [Test, Order(2)]
        public void TestMethodForPlaceOrder()
        {
            product = new ProductPage();
            product.AddParticularProductToCart();
        }

        [Test, Order(3)]
        public void TestMethodNegativeTestCase()
        {
            invalidLogin = new InvalidLoginPageAction();
            invalidLogin.CheckInvalidLogin();
        }

        [Test, Order(4)]
        public void TestMethodForSendingReportByEmail()
        {
            email = new EmailClass();
            email.ReadDataFromExcel();
            email.email_send();
        }
    }
}