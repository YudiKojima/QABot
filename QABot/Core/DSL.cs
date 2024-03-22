using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace QABot.Core
{
    public class DSL : GlobalVariables
    {
        #region Manipulation Function
        public static void Wait(int time)
        {
            Thread.Sleep(time);
        }

        public void ClearData(string element)
        {
            driver.FindElement(By.XPath(element)).Clear();
        }

        public void ClickOut()
        {
            driver.FindElement(By.XPath("//html")).Click();
        }

        public void WaitElement(string element, int seconds = 90)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until((d) => d.FindElement(By.XPath(element)));
        }

        public void WaitElementGone(string element)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            wait.Until((d) => d.FindElements(By.XPath(element)).Count == 0);
        }

        public bool ValidElementExist(string element)
        {
            try
            {
                driver.FindElement(By.XPath(element));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        #endregion

        #region Interaction Function
        #endregion

        #region Assignment Function
        public void WriteByName(string name, string value)
        {
            driver.FindElement(By.Name(name)).SendKeys(value);
        }

        public void ClickByName(string name)
        {
            driver.FindElement(By.Name(name)).Click();
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
        #endregion
    }
}