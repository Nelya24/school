using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class LoginPage
    {
        private IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        private IWebElement LoginHeader => _driver.FindElement(By.XPath("//h2[text()='Login']"));
        private IWebElement UsernameOrEmailLabel => _driver.FindElement(By.XPath("//*[contains(text(),'Username or')]"));
        private IWebElement UsernameInputField => _driver.FindElement(By.XPath("//*[@id='username']"));
        private IWebElement PasswordLogLabel => _driver.FindElement(By.XPath(""));
        private IWebElement PasswordLogInputField => _driver.FindElement(By.XPath("//*[@id='password']"));
        private IWebElement LoginButton => _driver.FindElement(By.XPath("//input[@name='login']"));
        private IWebElement RememberMeCheckbox => _driver.FindElement(By.XPath("//*[@id='rememberme']"));
        private IWebElement LostPassswordLink => _driver.FindElement(By.XPath("//a[@href and contains(text(), 'Lost')]"));
        private IWebElement RegisterHeader => _driver.FindElement(By.XPath("//h2[text()='Register']"));
        private IWebElement EmailAddressLabel => _driver.FindElement(By.XPath("//*[contains(text(),'Email')]"));
        private IWebElement EmailInputField => _driver.FindElement(By.XPath("//*[@id='reg_email']"));
        private IWebElement PasswordRegLabel => _driver.FindElement(By.XPath("//*[contains(text(),'Password')][2]"));
        private IWebElement PasswordRegInputField => _driver.FindElement(By.XPath("//*[@id='reg_password']"));
        private IWebElement RegisterButton => _driver.FindElement(By.XPath("//input[@name='register']"));

        public string GetLostPassword() //method to get the text value "Lost your password?"
        {
            IWebElement lostPasswordLink = _driver.FindElement(By.XPath("//a[@href and contains(text(), 'Lost')]"));
            return lostPasswordLink.Text;
        }
        public string GetRememberMe() //method to get the text value "Remember me"
        {
            IWebElement rememberMe = _driver.FindElement(By.XPath("//*[@id='rememberme']"));
            return rememberMe.Text;
        }
        public string GetRegisterSubmit() //method to get text value "Register"
        {
            IWebElement registerButton = _driver.FindElement(By.XPath("//input[@name='register']"));
            return registerButton.Text;
        }
    }
}
