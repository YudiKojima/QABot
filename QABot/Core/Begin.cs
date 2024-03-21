using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace QABot.Core
{
    public class Begin : DSL
    {
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driverQuit = false;
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