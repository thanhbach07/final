//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;

//namespace SeleniumTests
//{
//    [TestClass]
//    public class LoginTests
//    {
//        private IWebDriver driver;
//        private WebDriverWait wait;

//        [TestInitialize]
//        public void Setup()
//        {
//            driver = new ChromeDriver();
//            driver.Manage().Window.Maximize();
//            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//        }

//        [TestMethod]
//        public void Test_ValidLogin()
//        {
//            // Mở trang đăng nhập
//            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

//            // Đợi trường nhập xuất hiện
//            IWebElement usernameInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("user-name")));
//            IWebElement passwordInput = driver.FindElement(By.Id("password"));
//            IWebElement loginButton = driver.FindElement(By.Id("login-button"));

//            // Nhập thông tin đăng nhập
//            usernameInput.SendKeys("standard_user");
//            passwordInput.SendKeys("secret_sauce");
//            loginButton.Click();

//            // Kiểm tra đăng nhập thành công bằng cách kiểm tra nút mở menu xuất hiện
//            bool isLoggedIn = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("react-burger-menu-btn"))) != null;

//            Assert.IsTrue(isLoggedIn, "Đăng nhập thất bại!");
//        }

//        [TestCleanup]
//        public void TearDown()
//        {
//            driver.Quit();
//        }
//    }
//}



using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTests
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [TestMethod]
        public void Test_ValidLogin()
        {
            driver.Navigate().GoToUrl("https://localhost:7061/User/Login");

            try
            {
                // Nhập email & mật khẩu
                IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[type='email']")));
                IWebElement passwordInput = driver.FindElement(By.CssSelector("input[type='password']"));
                IWebElement loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));

                emailInput.SendKeys("toi1@gmail.com");
                passwordInput.SendKeys("Bach2005@"); // Thử nhập đúng hoặc sai mật khẩu
                loginButton.Click();

                // Chờ 3 giây xem có lỗi không
                System.Threading.Thread.Sleep(3000);

                try
                {
                    // Kiểm tra nếu có thông báo lỗi (đăng nhập thất bại)
                    IWebElement errorMessage = driver.FindElement(By.CssSelector(".error-message"));
                    string errorText = errorMessage.Text;
                    Console.WriteLine("Lỗi hiển thị: " + errorText);

                    Assert.Fail("Sai mật khẩu nhưng hệ thống vẫn cho đăng nhập!");
                }
                catch (NoSuchElementException)
                {
                    // Nếu không có lỗi -> Đăng nhập thành công
                    Console.WriteLine("✅ Đăng nhập thành công!");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Lỗi trong quá trình đăng nhập: " + ex.Message);
            }
        }

        //[TestMethod]
        //public void Test_InvalidLogin_WrongPassword()
        //{
        //    driver.Navigate().GoToUrl("https://localhost:7061/User/Login");

        //    try
        //    {
        //        // Tìm và nhập dữ liệu sai mật khẩu
        //        IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[type='email']")));
        //        IWebElement passwordInput = driver.FindElement(By.CssSelector("input[type='password']"));
        //        IWebElement loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));

        //        emailInput.SendKeys("toi1@gmail.com");
        //        passwordInput.SendKeys("SaiMatKhau123!");
        //        loginButton.Click();

        //        // Kiểm tra nếu hiển thị thông báo lỗi
        //        IWebElement errorMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".error-message")));
        //        string errorText = errorMessage.Text;

        //        Assert.IsTrue(errorText.Contains("Sai mật khẩu"), "❌ Thông báo lỗi không hiển thị!");
        //        Console.WriteLine("✅ Hiển thị lỗi mật khẩu sai!");
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.Fail("Lỗi khi kiểm tra mật khẩu sai: " + ex.Message);
        //    }
        //}

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}





