using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace QABot.Core
{
    public class Begin : DSL
    {
        #region OpenNavigator
        private void OpenNavigator()
        {
            var headlessMode = new ChromeOptions();
            headlessMode.AddArgument("window-size=1920x1080");
            headlessMode.AddArgument("disk-cache-size=0");
            headlessMode.AddArgument("headless");

            var devMode = new ChromeOptions();
            devMode.AddArgument("disk-cache-size=0");
            devMode.AddArgument("start-maximized");

            if (headlessTest)
            {
                driver = new ChromeDriver(headlessMode);
            }
            else
            {
                driver = new ChromeDriver(devMode);
                driverQuit = false;
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        #endregion

        #region Setup
        [SetUp]
        public void Setup()
        {
            OpenNavigator();
        }
        #endregion

        #region TearDown
        [TearDown]
        public void TearDown()
        {
            if (driverQuit)
            {
                driver.Quit();
            }
        }
        #endregion
    }
}