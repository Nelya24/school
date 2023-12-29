using OpenQA.Selenium;

namespace TestProject1
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By _searchIcon = By.XPath("//*[@id='s']");
        private readonly By _searchTitle = By.XPath("//h1[@class='page-title']");
        private const string _expectedSearchInput = "HTML";
        private readonly By _SearchResult = By.XPath("//h2[contains(text(),'')]/a");

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://practice.automationtesting.in/shop/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void HtmlSearch()
        {
            var search = driver.FindElement(_searchIcon);

            search.SendKeys("html");
            search.SendKeys(Keys.Enter);
            var actualSearchInput = driver.FindElement(_searchTitle).Text;

            Assert.That(actualSearchInput, Does.Contain(_expectedSearchInput)); //check that the search result title contains "HTML"

            var searchResult = driver.FindElements(_SearchResult);
            for (int i = 0; i < 3; i++)
            {
                var linkValue = searchResult[i].GetAttribute("href");
                var locatorText = searchResult[i].Text;
                Assert.IsTrue(linkValue.Contains("https")); //check that the search results contain "https"
                Assert.IsTrue(locatorText.Contains("HTML")); //check that the search results contain "HTML"
            }
        }
    }
}