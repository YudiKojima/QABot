using NUnit.Framework;
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
        public void WriteByElement(string element, string value, string? description = null)
        {
            try
            {
                driver.FindElement(By.XPath(element)).SendKeys(value);

                if (description != null)
                {
                    Console.WriteLine("Preencheu " + description);
                }
            }
            catch
            {
                if (description != null)
                {
                    Console.WriteLine("Erro ao preencher " + description);
                }

                Assert.Fail();
            }
        }

        public void ClickByElement(string element, string? description = null)
        {
            try
            {
                driver.FindElement(By.XPath(element)).Click();
                Wait(1000);

                if (description != null)
                {
                    Console.WriteLine("Clicou " + description);
                }
            }
            catch
            {
                if (description != null)
                {
                    Console.WriteLine("Erro ao clicar " + description);
                }

                Assert.Fail();
            }
        }

        public void ValidateData(string element, string value, string? description = null)
        {
            try
            {
                Assert.That(driver.FindElement(By.XPath(element)).Text, Does.Contain(value));

                if (description != null)
                {
                    Console.WriteLine("Validou " + description);
                }
            }
            catch
            {
                if (description != null)
                {
                    Console.WriteLine("Erro ao validar " + description);
                }

                Assert.Fail();
            }
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

        #region Assignment Function
        #endregion
    }
}