using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace QABot.Core
{
    public class Begin
    {
        public IWebDriver driver;
        public bool driverQuit = true;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            // gerar e armazenar email
            driver.Navigate().GoToUrl("https://www.invertexto.com/gerador-email-temporario");
            driver.Manage().Window.Maximize();
            IWebElement emailElement = driver.FindElement(By.Id("email-input"));
            var email = emailElement.GetAttribute("value");

            // gerar e armazenar cnpj
            driver.Navigate().GoToUrl("https://www.invertexto.com/gerador-de-cnpj");
            driver.FindElement(By.Id("gerar")).Click();
            IWebElement cnpjElement = driver.FindElement(By.Id("cnpj"));
            var cnpj = cnpjElement.GetAttribute("value");
        }

        [TearDown]
        public void TearDown()
        {
            if (driverQuit)
            {
                driver.Quit();
            }
        }
    }
}