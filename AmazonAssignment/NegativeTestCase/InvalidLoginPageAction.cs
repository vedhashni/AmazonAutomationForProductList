using AmazonAssignment.WebPageActions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonAssignment.NegativeTestCase
{
    public class InvalidLoginPageAction:Base.BaseClass
    {
        public static ExcelOperation excel2;
        public static LoginPageAction loginPage;
        public void CheckInvalidLogin()
        {
            excel2 = new ExcelOperation();
            loginPage = new LoginPageAction();
            loginPage.ReadDataFromExcel();
            InvalidLoginPageData invalid = new InvalidLoginPageData(driver);
            invalid.login.Click();
            invalid.email.SendKeys(excel2.ReadData(2,"Email"));
            invalid.continuebtn.Click();
            invalid.password.SendKeys(excel2.ReadData(2,"Password"));
            invalid.signin.Click();
            Assert.True(invalid.alertmessage.Displayed);
        }
    }
}
