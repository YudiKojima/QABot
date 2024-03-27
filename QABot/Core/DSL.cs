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

        public void ClearValue(string element)
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

        public bool ValidateElementExist(string element)
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
        public void WriteByElement(string element, string value, string? description = null, bool pressEnter = false)
        {
            try
            {
                driver.FindElement(By.XPath(element)).SendKeys(value);

                if (pressEnter)
                {
                    Wait(1500);
                    driver.FindElement(By.XPath(element)).SendKeys(Keys.Enter);
                }

                if (description != null)
                {
                    Console.WriteLine("Preencheu " + description);
                }
            }
            catch (Exception ex)
            {
                if (description != null)
                {
                    Console.WriteLine("Erro ao preencher " + description + exceptionMessage + ex.Message);
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
            catch (Exception ex)
            {
                if (description != null)
                {
                    Console.WriteLine("Erro ao clicar " + description + exceptionMessage + ex.Message);
                }

                Assert.Fail();
            }
        }

        public void ValidateValue(string element, string value, string? description = null)
        {
            try
            {
                Assert.That(driver.FindElement(By.XPath(element)).Text, Does.Contain(value));

                if (description != null)
                {
                    Console.WriteLine("Validou " + description);
                }
            }
            catch (Exception ex)
            {
                if (description != null)
                {
                    Console.WriteLine("Erro ao validar " + description + exceptionMessage + ex.Message);
                }

                Assert.Fail();
            }
        }

        public void DropDownMenu(string element, string value, string? description = null)
        {
            try
            {
                string xPathElement = "//*[text()='" + value + "']";
                ClickByElement(element);
                WaitElement(xPathElement);
                ClickByElement(xPathElement);

                if (description != null)
                {
                    Console.WriteLine("Selecionou menu DropDown " + description);
                }
            }
            catch (Exception ex)
            {
                if (description != null)
                {
                    Console.WriteLine("Erro ao selecionar menu DropDown " + description + exceptionMessage + ex.Message);
                }

                Assert.Fail();
            }
        }
        #endregion

        #region Assignment Function
        public string GenerateName()
        {
            driver.Navigate().GoToUrl("https://www.invertexto.com/gerador-de-pessoas");
            DropDownMenu("//select[@name=\"country\"]", "Brasil", "Nacionalidade");
            ClickByElement("/html/body/main/div/div/div[1]/form/div[3]/div/button", "no botão Gerar Pessoa");
            var nameElement = driver.FindElement(By.XPath("/html/body/main/div/div/div[2]/div[2]/section[1]/div[1]/input"));

            return nameElement.GetAttribute("value");
        }

        public string GenerateTempEmail()
        {
            driver.Navigate().GoToUrl("https://www.invertexto.com/gerador-email-temporario");
            var emailElement = driver.FindElement(By.XPath("//*[@id=\"email-input\"]"));

            return emailElement.GetAttribute("value");
        }

        public string GenerateCpf()
        {
            driver.Navigate().GoToUrl("https://www.invertexto.com/gerador-de-cpf");
            ClickByElement("//*[@id=\"pontuacao\"]", "no checkbox Pontuação");
            ClickByElement("//*[@id=\"gerar\"]", "no botão Gerar CPF");
            var cpfElement = driver.FindElement(By.XPath("//*[@id=\"cpf\"]"));

            return cpfElement.GetAttribute("value");
        }

        public string GenerateCnpj()
        {
            driver.Navigate().GoToUrl("https://www.invertexto.com/gerador-de-cnpj");
            ClickByElement("//*[@id=\"gerar\"]", "no botão Gerar CNPJ");
            var cnpjElement = driver.FindElement(By.XPath("//*[@id=\"cnpj\"]"));

            return cnpjElement.GetAttribute("value");
        }

        public string GenerateCep()
        {
            driver.Navigate().GoToUrl("https://www.invertexto.com/gerador-de-cep");
            ClickByElement("//input[@id=\"pontuacao\"]", "no checkbox Pontuação");
            ClickByElement("//button[@id=\"gerar\"]", "no botão Gerar CEP");
            var cepElement = driver.FindElement(By.XPath("//input[@id=\"cep\"]"));

            return cepElement.GetAttribute("value");
        }

        public static string GenerateRandomDate(int startYear = 1960, string outputDateFormat = "ddMMyyyy")
        {
            var start = new DateTime(startYear, 1, 1);
            var gen = new Random(Guid.NewGuid().GetHashCode());
            var range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range)).ToString(outputDateFormat);
        }

        public static string GenerateRandomPhone()
        {
            var gen = new Random(Guid.NewGuid().GetHashCode());
            var phoneNumber = string.Empty;

            for (int i = 0; i < 11; i++)
            {
                phoneNumber = string.Concat(phoneNumber, gen.Next(10));
            }

            return phoneNumber;
        }
        #endregion

        #region Global Function
        public virtual void SignInSpedy()
        {
            driver.Navigate().GoToUrl("http://localhost:3000/signin");
            WriteByElement("//input[@name=\"email\"]", "marcos.silva@spedy.com.br", "o campo Seu endereço de e-mail");
            WriteByElement("//input[@name=\"password\"]", "teste123", "o campo Sua senha");
            ClickByElement("//*[@id=\"root\"]/div/form/button", "no botão Acessar");
        }

        #endregion
    }
}