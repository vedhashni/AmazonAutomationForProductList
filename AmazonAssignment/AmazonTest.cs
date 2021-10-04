/*summary : Amazon Automation of product list display
  Author: Vedhashni V
  Date  : 11-09-21
*/


using AmazonAssignment.ActionDo;
using AmazonAssignment.Email;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AmazonAssignment
{
    public class AmazonTest:Base.BaseClass
    {
        public static DoAction pageaction;
        public static EmailClass email;
        ExtentReports report = Report.report();
        ExtentTest test;

        [Test,Order(0)]
        public void TestMethodForSignUp()
        {
            pageaction = new DoAction();
            pageaction.SignupIntoAmazon();
        }


        //Used to read the data from excel
        //Used to login into Amazon with credentials given in the excel
        [Test, Order(1)]
        public void TestMethodForLoginIntoAmazon()
        {
            test = report.CreateTest("AmazonTests");
            test.Log(Status.Info, "Amazon Automation");
            pageaction = new DoAction();
            pageaction.LoginIntoAmazon();
            TakeScreenShot();
            System.Threading.Thread.Sleep(200);
            test.Info("ScreenShot", MediaEntityBuilder.CreateScreenCaptureFromPath(@"C:\Users\vedhashni.v\source\repos\AmazonAssignment\AmazonAssignment\TakeScreeShot\AmazonTest.png").Build());
            //test.Info("Details", MediaEntityBuilder.CreateScreenCaptureFromPath(@"C:\Users\vedhashni.v\source\repos\ReportGenerationForAmazon\ReportGenerationForAmazon\TestScreenShots\AmazonTest.png").Build());
            test.Log(Status.Pass, "TestCases Passed");
            report.Flush();
        }

        //Used to Search the product
        [Test, Order(2)]
        public void TestMethodForSearchProduct()
        {
            pageaction = new DoAction();
            pageaction.SearchProductsInAmazonAfterLogin();
            pageaction.ListOfProductsBrandName();
            pageaction.PriceOfProduct();
        }

        [Test, Order(3)]
        public void TestMethodForAddToCart()
        {
            pageaction = new DoAction();
            pageaction.AddParticularProductToCart();
        }

        [Test, Order(4)]
        public void TestMethodToOrder()
        {
            pageaction = new DoAction();
            pageaction.ToPlaceOrder();
        }

        [Test, Order(5)]
        public void TestMethodForSendingReportByEmail()
        {
           email = new EmailClass();
            email.ToSendReportThroughEmail();
        }
    }
}