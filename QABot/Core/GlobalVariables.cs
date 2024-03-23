using OpenQA.Selenium;

namespace QABot.Core
{
    public class GlobalVariables
    {
        public IWebDriver driver;
        public bool driverQuit = true;
        public bool headlessTest = false;

        public string name = string.Empty;
        public string email = string.Empty;
    }
}
