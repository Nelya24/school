using OpenQA.Selenium;

namespace TestProject1
{
    public class LoginPage
    {
        private IWebDriver _driver;
        private By loginButtonLocator;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement LoginHeader => _driver.FindElement(By.XPath("//h2[text()='Login']"));
        private IWebElement UsernameOrEmailLabel => _driver.FindElement(By.XPath("//*[contains(text(),'Username or')]"));
        private IWebElement UsernameInputField => _driver.FindElement(By.XPath("//*[@id='username']"));
        private IWebElement PasswordLogLabel => _driver.FindElement(By.XPath(""));
        private IWebElement PasswordLogInputField => _driver.FindElement(By.XPath("//*[@id='password']"));
        private IWebElement LoginButton => _driver.FindElement(By.XPath("//input[@name='login']"));
        private IWebElement RememberMeCheckbox => _driver.FindElement(By.XPath("//*[@id='rememberme']/parent::label"));
        private IWebElement LostPassswordLink => _driver.FindElement(By.XPath("//a[@href and contains(text(), 'Lost')]"));
        private IWebElement RegisterHeader => _driver.FindElement(By.XPath("//h2[text()='Register']"));
        private IWebElement EmailAddressLabel => _driver.FindElement(By.XPath("//*[contains(text(),'Email')]"));
        private IWebElement EmailInputField => _driver.FindElement(By.XPath("//*[@id='reg_email']"));
        private IWebElement PasswordRegLabel => _driver.FindElement(By.XPath("//*[contains(text(),'Password')][2]"));
        private IWebElement PasswordRegInputField => _driver.FindElement(By.XPath("//*[@id='reg_password']"));
        private IWebElement RegisterButton => _driver.FindElement(By.XPath("//form[@class='register']//input[@type='submit']"));
        private IWebElement ErrorLogin => _driver.FindElement(By.XPath("//*[@id='page-36']/div/div[1]/ul/li/strong[1]"));

        public string GetLostPassword() //method to get the text value "Lost your password?"
        {
            return LostPassswordLink.Text;
        }
        public string GetRememberMe() //method to get the text value "Remember me"
        {
            return RememberMeCheckbox.Text;
        }
        public string GetRegisterSubmit() //method to get text value "Register"
        {
            return RegisterButton.GetAttribute("value");
        }

        // method for entering username or email address
        public void EnterUsernameOrEmail(string usernameOrEmail)
        {
            IWebElement usernameField = UsernameInputField;
            usernameField.Clear();
            usernameField.SendKeys(usernameOrEmail);
        }

        // method for entering password
        public void EnterPassword(string password)
        {
            IWebElement passwordField = PasswordLogInputField;
            passwordField.Clear();
            passwordField.SendKeys(password);
        }

        // method for clicking the "Login" button
        public void ClickLoginButton()
        {
            IWebElement loginButton = LoginButton;
            loginButton.Click();
        }

        //method for getting login error
        public string GetLoginError() 
       {
           IWebElement errorLogin = ErrorLogin;
           return ErrorLogin.Text;
       }
    }
}

