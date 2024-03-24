using OpenQA.Selenium;

namespace QABot.Core
{
    public class GlobalVariables
    {
        public IWebDriver driver;
        public bool driverQuit = true;
        public bool headlessTest = false;
        public string URL = "http://localhost:3000/signup";

        public string name = string.Empty;
        public string email = string.Empty;
        public string federalTaxNumber = string.Empty;
        public string postalCode = string.Empty;
    }
}
