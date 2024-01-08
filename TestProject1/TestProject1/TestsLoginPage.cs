using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class TestsLoginPage
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _driver.Navigate().GoToUrl("https://practice.automationtesting.in/my-account/");
            _driver.Manage().Window.Maximize();
            _loginPage = new LoginPage(_driver);
        }
        [Test]

        public void TestLoginPageElements()
        {
            // checking the link text "Lost your password?"
            string lostPasswordLink = _loginPage.GetLostPassword();
            Assert.AreEqual("Lost your password?", lostPasswordLink);

            // checking the text checkbox "Remember me"
            string rememberMeText = _loginPage.GetRememberMe();
            Assert.AreEqual("Remember me", rememberMeText);

            // checking the text of the "Register" button
            string registerButtonText = _loginPage.GetRegisterSubmit();
            Assert.AreEqual("Register", registerButtonText);

        }

        [Test]
        public void LoginWithInValidCredentials()
            {
            //entering credentials
            _loginPage.EnterUsernameOrEmail("test@email.com");
            _loginPage.EnterPassword("test-password");

            //clicking "Login" button
            _loginPage.ClickLoginButton();
            
            //checking that invalid input calls login error 
            string getErrorLogin = _loginPage.GetLoginError();
            Assert.AreEqual("A user could not be found with this email address.", getErrorLogin);

        }
        }
    }


