using NUnit.Framework;
using OpenQA.Selenium;
using QABot.Core;

namespace QABot
{
    internal class SignUp : Begin
    {
        [Test]
        public void Test()
        {
            // criar uma conta no stageApp
            driver.Navigate().GoToUrl("https://stage-app.spedy.com.br/signup");
            driver.FindElement(By.Name("name")).SendKeys("teste auto");
            driver.FindElement(By.Name("email")).SendKeys("x");
            driver.FindElement(By.Name("phoneNumber")).SendKeys("66666666666");
            driver.FindElement(By.Name("password")).SendKeys("teste123");
            driver.FindElement(By.Name("checkbox")).Click();
        }
    }
}