using OpenQA.Selenium;
using System;

namespace QABot.Core
{
    public class GlobalVariables
    {
        public IWebDriver driver;
        public bool driverQuit = true;
        public bool headlessTest = false;
        public string exceptionMessage = "\nSelenium Message Error: ";

        public string signUpName = string.Empty;
        public string signUpEmail = string.Empty;
        public string signUpFederalTaxNumber = string.Empty;
        public string signUpPostalCode = string.Empty;

        public enum SubscriptionPlan
        {
            Free,
            EssentialMonthly,
            AdvancedMonthly,
            ProfessionalMonthly,
            EssentialYearly,
            AdvancedYearly,
            ProfessionalYearly,
        }

        public enum InvoiceModel
        {
            ServiceInvoice,
            ProductInvoice,
            Split
        }

        [Flags]
        public enum PaymentMethod
        {
            CreditCard = 1,
            Billet = 2,
            Pix = 4
        }
    }
}
