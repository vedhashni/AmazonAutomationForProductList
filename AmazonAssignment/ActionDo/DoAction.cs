using AmazonAssignment.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonAssignment.ActionDo
{
    public class DoAction:Base.BaseClass
    {
        public static LoginPage login;
        public static ExcelOperation excel;
        public static Homepage homepage;
        public static ProductPage product;
        public static CheckOutPage checkOut;
        public static SignUpPage sign;
        public static LogoutPage logout;

        public void SignupIntoAmazon()
        {
            excel = new ExcelOperation();
            sign = new SignUpPage(driver);
            login = new LoginPage(driver);
            try
            {
                if (login.logo.Displayed)
                {
                    sign.signup.Click();
                    System.Threading.Thread.Sleep(1000);
                    excel.PopulateFromExcel(@"C:\Users\vedhashni.v\source\repos\AmazonAssignment\AmazonAssignment\DataForTesting\ExcelDataAmazon.xlsx");
                    //By invoking the readdate method values in table is retrived
                    sign.name.SendKeys(excel.ReadData(1, "Name"));
                    //is used to wait in a particular page before taking another action
                    System.Threading.Thread.Sleep(4000);
                    //By invoking the readdate method values in table is retrived
                    sign.mobilenumber.SendKeys(excel.ReadData(1, "MobileNumber"));
                    //is used to wait in a particular page before taking another action
                    System.Threading.Thread.Sleep(3000);
                    //By invoking the readdate method values in table is retrived
                    sign.email.SendKeys(excel.ReadData(1, "EmailForSignUp"));
                    //is used to wait in a particular page before taking another action
                    System.Threading.Thread.Sleep(3000);
                    //By invoking the readdate method values in table is retrived
                    sign.password.SendKeys(excel.ReadData(1, "PasswordSignUp"));
                    //is used to wait in a particular page before taking another action
                    System.Threading.Thread.Sleep(3000);
                    sign.continuebtn.Click();
                    System.Threading.Thread.Sleep(1000);
                    //register.newaccountbtn.Click();
                    //System.Threading.Thread.Sleep(10000);
                    log.Info("Registered Successfully");
                }
                else
                {
                    log.Info("Not Registered Successfully");
                }
            }
            catch
            {
                throw new CustomException(CustomException.ExceptionType.NoSuchElementException, "Webdriver unable to locate the element");
            }
        }


        public void LoginIntoAmazon()
        {
            login = new LoginPage(driver);
            excel = new ExcelOperation();
            try
            {
                if (login.logo.Displayed)
                {
                    login.login.Click();
                    System.Threading.Thread.Sleep(1000);
                    excel.PopulateFromExcel(@"C:\Users\vedhashni.v\source\repos\AmazonAssignment\AmazonAssignment\DataForTesting\ExcelDataAmazon.xlsx");
                    //By invoking the readdate method values in table is retrived
                    login.email.SendKeys(excel.ReadData(1, "Email"));
                    //shot.TakeScreenShot();
                    //is used to wait in a particular page before taking another action
                    System.Threading.Thread.Sleep(1000);
                    //Here we click continue button for further process
                    login.continuebtn.Click();
                    //is used to wait in a particular page before taking another action
                    System.Threading.Thread.Sleep(1000);
                    //By invoking the readdate method values in table is retrived
                    login.password.SendKeys(excel.ReadData(1, "Password"));
                    //ScreenShot.TakeScreenShot(driver);
                    System.Threading.Thread.Sleep(1000);
                    login.signin.Click();
                    System.Threading.Thread.Sleep(1000);
                    if (login.message.Displayed)
                    {
                        log.Info("Logged In Successfully");
                    }
                    else
                    {
                        log.Info("Not Logged In Successfully");
                    }
                }
                else
                {
                    log.Info("Credential Not Given");
                }
            }
            catch
            {
                throw new CustomException(CustomException.ExceptionType.NoSuchElementException, "Webdriver unable to locate the element");
            }
        }

        public void SearchProductsInAmazonAfterLogin()
        {
            login = new LoginPage(driver);
            homepage = new Homepage(driver);
            excel = new ExcelOperation();
            try
            {
                LoginIntoAmazon();
                if (login.message.Displayed)
                {
                    //Here search bar element is finded
                    IWebElement element = homepage.searchbar;
                    //By using this search bar is clicked
                    element.SendKeys(Keys.Control + "a");
                    //ScreenShot.TakeScreenShot(driver);
                    System.Threading.Thread.Sleep(500);
                    //Value is sent to find specific product
                    excel.PopulateFromExcel(@"C:\Users\vedhashni.v\source\repos\AmazonAssignment\AmazonAssignment\DataForTesting\ExcelDataAmazon.xlsx");
                    element.SendKeys(excel.ReadData(1, "SearchProduct"));
                    //ScreenShot.TakeScreenShot(driver);
                    System.Threading.Thread.Sleep(500);
                    if (element != null)
                    {
                        //By keys class arrowup used to select the value listed down the search bar
                        element.SendKeys(Keys.ArrowUp);
                        System.Threading.Thread.Sleep(500);
                        //By keys class arrowdown used to select the value listed down the search bar
                        element.SendKeys(Keys.ArrowDown);
                        System.Threading.Thread.Sleep(500);
                        element.SendKeys(Keys.ArrowDown);
                        System.Threading.Thread.Sleep(500);

                        //By using this particular product is searched by clicking the enter key instead search icon
                        element.SendKeys(Keys.Enter);

                        //System.Threading.Thread.Sleep(15000);
                        System.Threading.Thread.Sleep(1000);
                        log.Info("Given Product is searched");
                    }
                    else
                    {
                        log.Info("Mismatch Product is searched");
                    }
                }
                else
                {
                    log.Info("User not logged in");
                }
            }
            catch
            {
                throw new CustomException(CustomException.ExceptionType.NoSuchElementException, "Webdriver unable to locate the element");
            }
        }

        //Used to retrive brand's name
        public void ListOfProductsBrandName()
        {
            try
            {
                //Getting the list of product brand's name by using class
                IList<IWebElement> productbrandname = driver.FindElements(By.ClassName("s-line-clamp-1"));
                foreach (IWebElement currentproductbrandname in productbrandname)
                {
                    //getting the brandname of each current product 
                    //Text is used to get the name of innerelements in webpages
                    string brandname = currentproductbrandname.Text;
                    Console.WriteLine("PRODUCT NAME :" + brandname);
                }
                //Calling this method to print the ratings of each product 
                //RatingsOfEachBrandedProduct();
            }
            catch
            {
                throw new CustomException(CustomException.ExceptionType.NoSuchElementException, "webdriver is unable to find and loacate elements");
            }
        }

        //Used to retrive ratings of each product
        public static void RatingsOfEachBrandedProduct()
        {
            try
            {
                IList<string> productRating = new List<string>();
                foreach (var r in driver.FindElements(By.XPath("//*[@class='a-popover-trigger a-declarative']")))
                {
                    r.Click();
                    System.Threading.Thread.Sleep(5000);
                    foreach (var rating in driver.FindElements(By.CssSelector("span[class='a-size-medium a-color-base a-text-beside-button a-text-bold']")))
                    {
                        if (!string.IsNullOrEmpty(rating.Text))
                        {
                            productRating.Add(rating.Text);
                            Console.WriteLine("Product Rating {0}", rating.Text);
                        }
                        else
                        {
                            productRating.Remove(rating.Text);
                        }
                    }
                }

            }
            catch
            {
                throw new CustomException(CustomException.ExceptionType.NoSuchElementException, "webdriver is unable to find and loacate elements");
            }
        }

        public void PriceOfProduct()
        {
            try
            {
                IList<IWebElement> priceofproduct = driver.FindElements(By.ClassName("a-price"));
                foreach (IWebElement price in priceofproduct)
                {
                    string productprice = price.Text;
                    Console.WriteLine("Price :" + productprice);
                }
            }
            catch
            {
                throw new CustomException(CustomException.ExceptionType.NoSuchElementException, "webdriver is unable to find and loacate elements");
            }
        }

        public void AddParticularProductToCart()
        {
            product = new ProductPage(driver);
            excel = new ExcelOperation();
            login = new LoginPage(driver);
            try
            {
                SearchProductsInAmazonAfterLogin();
                product.product.Click();
                var newTabHandle = driver.WindowHandles[1];
                if (newTabHandle != null)
                {
                    driver.SwitchTo().Window(newTabHandle);
                    System.Threading.Thread.Sleep(2000);
                    product.addtowishlist.Click();
                    System.Threading.Thread.Sleep(2000);
                    product.viewwishlist.Click();
                    string viewpage = "https://www.amazon.in/gp/registry/wishlist/2U18WJG4AUH86/ref=cm_wl_huc_view";
                    string actualviewpage = driver.Url;
                    Assert.AreEqual(viewpage, actualviewpage);
                    System.Threading.Thread.Sleep(2000);
                    product.addtocart.Click();
                    System.Threading.Thread.Sleep(2000);
                    log.Info("Product successfully added into the cart");
                }
                else
                {
                    log.Info("product is not selected");
                }
            }
            catch
            {
                throw new CustomException(CustomException.ExceptionType.NoSuchElementException, "Webdriver unable to locate the element");
            }
        }

        public void ToPlaceOrder()
        {
            checkOut = new CheckOutPage(driver);
            product = new ProductPage(driver);
            try
            {
                AddParticularProductToCart();
                product.proceedtocheckout.Click();
                if (checkOut.checkoutpagediplayed.Displayed)
                {
                    checkOut.selectaddress.Click();
                    System.Threading.Thread.Sleep(1000);
                    checkOut.usethisaddressbtn.Click();
                    System.Threading.Thread.Sleep(8000);
                    checkOut.selectmodeofpayment.Click();
                    System.Threading.Thread.Sleep(1000);
                    checkOut.usethispaymentbtn.Click();
                    System.Threading.Thread.Sleep(1000);
                    TakeScreenShot();
                    //checkOut.placeorderbtn.Click();
                    log.Info("Order placed successfully");
                }
                else
                {
                    log.Info("Checkout page is not visible");
                }
            }
            catch
            {
                throw new CustomException(CustomException.ExceptionType.NoSuchElementException, "Webdriver unable to locate the element");
            }
        }

        public void LogoutFromAmazon()
        {
            login = new LoginPage(driver);
            logout = new LogoutPage(driver);
            excel = new ExcelOperation();
            try
            {
                LoginIntoAmazon();
                if (login.message.Displayed)
                {
                    Actions action = new Actions(driver);
                    action.MoveToElement(logout.accountarrow).Perform();
                    logout.signout.Click();
                    System.Threading.Thread.Sleep(1000);
                    excel.PopulateFromExcel(@"C:\Users\vedhashni.v\source\repos\AmazonAssignment\AmazonAssignment\DataForTesting\ExcelDataAmazon.xlsx");
                    //By invoking the readdate method values in table is retrived
                    logout.email.SendKeys(excel.ReadData(1, "Email"));
                    logout.Continuebtn.Click();
                    System.Threading.Thread.Sleep(1000);
                }

            }
            catch
            {
                throw new CustomException(CustomException.ExceptionType.NoSuchElementException, "Webdriver unable to locate the element");
            }
        }

        public void CheckInvalidLogin()
        {
            excel = new ExcelOperation();
            login = new LoginPage(driver);
            try
            {
                if (login.logo.Displayed)
                {
                    login.login.Click();
                    excel.PopulateFromExcel(@"C:\Users\vedhashni.v\source\repos\AmazonAssignment\AmazonAssignment\DataForTesting\ExcelDataAmazon.xlsx");
                    login.email.SendKeys(excel.ReadData(2, "Email"));
                    login.continuebtn.Click();
                    login.password.SendKeys(excel.ReadData(2, "Password"));
                    login.signin.Click();
                    Assert.True(login.alertmessage.Displayed);
                }
            }
            catch
            {
                throw new CustomException(CustomException.ExceptionType.NoSuchElementException, "webdriver unable to locate the element");
            }
        }
    }
}
