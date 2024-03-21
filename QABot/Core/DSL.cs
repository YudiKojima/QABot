using OpenQA.Selenium;

namespace QABot.Core
{
    public class DSL : GlobalVariables
    {
        public void WriteByName(string name, string value)
        {
            driver.FindElement(By.Name(name)).SendKeys(value);
        }

        public void ClickByName(string name)
        {
            driver.FindElement(By.Name(name)).Click();
        }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        public string GenerateEmail()
        {
            driver.Navigate().GoToUrl("https://www.invertexto.com/gerador-email-temporario");
            driver.Manage().Window.Maximize();
            IWebElement emailElement = driver.FindElement(By.Id("email-input"));
            
            return emailElement.GetAttribute("value");
        }

        public string GenerateCnpj()
        {
            driver.Navigate().GoToUrl("https://www.invertexto.com/gerador-de-cnpj");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("gerar")).Click();
            IWebElement cnpjElement = driver.FindElement(By.Id("cnpj"));

            return cnpjElement.GetAttribute("value");
        }
    }
}
