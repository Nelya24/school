using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class Test2
    {
        private IWebDriver _driver;

        private readonly By _SaleIcon = By.XPath("//span[@class='onsale']");
        private const string _expectedSaleIcon = "SALE!";
        private static string PriceLocator(string price) => $"//span[text()='{price}']";
        private readonly By _HTML5card = By.XPath("//h3[text()='HTML5 WebApp Develpment']");
        private readonly By _AddToBasket = By.XPath("//div[2]/form/button");
        private readonly By _Name = By.XPath("//h1[text()='HTML5 WebApp Develpment']");
        private readonly By _Price = By.XPath("//span[text()='180.00']");
        private readonly By _Quantity = By.XPath("//*[@id ='product-182']/div[2]/form/div/input");
        private readonly By _GoToBasket = By.XPath("//*[@title='View your shopping cart']");
        private readonly By _ExpectedName = By.XPath("//*[contains(text(),'HTML5')]");
        private readonly By _ExpectedPrice = By.XPath("//*[contains(text(),'180.00')]");

        [SetUp]
        public void Setup()
        {
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _driver.Navigate().GoToUrl("https://practice.automationtesting.in/product/thinking-in-html/");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var actualSaleIcon = _driver.FindElement(_SaleIcon).Text;
            Assert.That(actualSaleIcon, Does.Contain(_expectedSaleIcon)); //check that the SALE label is displayed on the product picture

            var expectedPriceWithoutDiscount = _driver.FindElement(By.XPath(PriceLocator("450.00")));
            Assert.IsTrue(expectedPriceWithoutDiscount.Displayed, "Prices are not equal");

            var salePrice = _driver.FindElement(By.XPath(PriceLocator("400.00")));
            Assert.IsTrue(salePrice.Displayed, "Prices are not equal");

            var HTML5card = _driver.FindElement(_HTML5card); //go to the product card 'HTML5 WebApp Develpment'
            Actions actions2 = new Actions(_driver);
            actions2.ScrollToElement(HTML5card);
            actions2.Perform();
            HTML5card.Click();

            var AddToBasket = _driver.FindElement(_AddToBasket); //add item to cart
            Actions actions3 = new Actions(_driver);
            actions3.ScrollToElement(AddToBasket);
            actions3.Perform();
            AddToBasket.Click();

            var actualName = _driver.FindElement(_Name).Text;  //remember the full name 
            var actualPrice = _driver.FindElement(_Price).Text; //remember the price

            var Quantity = _driver.FindElement(_Quantity); //change the quantity of goods in the cart to 3
            Actions actions4 = new Actions(_driver);
            actions4.ScrollToElement(Quantity);
            actions4.Perform();
            Quantity.SendKeys(Keys.Delete);
            Quantity.SendKeys("2");
            Quantity.SendKeys(Keys.Enter);

            var GoToBasket = _driver.FindElement(_GoToBasket); //move to the basket
            Actions actions6 = new Actions(_driver);
            actions6.ScrollToElement(GoToBasket);
            actions6.Perform();
            GoToBasket.Click();

            var ExpectedName = _driver.FindElement(_ExpectedName).Text; //remember the full name in the basket
            var ExpectedPrice = _driver.FindElement(_ExpectedPrice).Text; //remember the full price in the basket

            Assert.That(actualName, Does.Contain(ExpectedName));
            Assert.That(actualPrice, Does.Contain(ExpectedPrice));

        }
    }
}

