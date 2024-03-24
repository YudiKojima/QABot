using OpenQA.Selenium;
using QABot.Core;

namespace QABot.Page
{
    public class SignUpPage : Begin
    {
        public void WriteName()
        {
            WriteByElement("//*[@id=\"root\"]/div/form/fieldset/div[1]/input", name, "o campo Seu nome completo");
        }

        public void WriteEmail()
        {
            WriteByElement("//*[@id=\"root\"]/div/form/fieldset/div[2]/input", email, "o campo Seu endereço de e-mail");
        }

        public void WritePhoneNumber()
        {
            var phoneNumber = GenerateRandomPhone();
            WriteByElement("//*[@id=\"root\"]/div/form/fieldset/div[3]/input", phoneNumber, "o campo Celular");
        }

        public void WritePassword()
        {
            WriteByElement("//*[@id=\"input-visible\"]", "teste123", "o campo Sua senha");
        }

        public void ClickCheckBox()
        {
            ClickByElement("//*[@id=\"root\"]/div/form/div[2]/input", "no checkbox Termos de uso");
        }

        public void ClickAccessButton()
        {
            ClickByElement("//*[@id=\"root\"]/div/form/button", "no botão Continuar");
        }

        public void ClickContinueButton()
        {
            Wait(5000);
            ClickByElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div/div/div[2]/button[2]", "no botão Já tenho uma empresa");
        }

        public void WriteCompany()
        {
            WriteByElement("//input[@id=\"federalTaxNumber\"]", federalTaxNumber, "o campo CNPJ");
            Wait(4000);

            var legalName = driver.FindElement(By.XPath("//input[@id=\"legalName\"]"));
            var fantasyName = driver.FindElement(By.XPath("//input[@id=\"name\"]"));


            if (legalName.GetAttribute("value").Length != 0 && fantasyName.GetAttribute("value").Length != 0)
            {
                return;
            }

            if (legalName.GetAttribute("value").Length != 0)
            {
                WriteByElement("//input[@id=\"name\"]", "nome fantasia", "o campo Nome fantasia");
                return;
            }

            WriteByElement("//input[@id=\"legalName\"]", "razao social teste", "o campo Razão Social");
            WriteByElement("//input[@id=\"name\"]", "nome fantasia", "o campo Nome fantasia");
        }

        public void WriteAddress()
        {
            var cep = driver.FindElement(By.XPath("//input[@id=\"address_postalCode\"]"));

            if (cep.GetAttribute("value").Length != 0)
            {
                ClearValue("//input[@id=\"address_number\"]");
                WriteByElement("//input[@id=\"address_number\"]", "123", "o campo Número");
                return;
            }

            WriteByElement("//input[@id=\"address_postalCode\"]", postalCode, "o campo CEP");
            Wait(4000);

            var street = driver.FindElement(By.XPath("//input[@id=\"address_street\"]"));
            var number = driver.FindElement(By.XPath("//input[@id=\"address_number\"]"));

            if (street.GetAttribute("value").Length != 0 && number.GetAttribute("value").Length != 0)
            {
                return;
            }

            if (street.GetAttribute("value").Length != 0)
            {
                WriteByElement("//input[@id=\"address_number\"]", "123", "o campo Número");
                return;
            }

            WriteByElement("//input[@id=\"address_street\"]", "rua teste", "o campo Logradouro");
            WriteByElement("//input[@id=\"address_number\"]", "123", "o campo Número");
            WriteByElement("//input[@id=\"address_district\"]", "bairro teste", "o campo Bairro");
            WriteByElement("//input[@id=\"address_city\"]", "Cuiaba", "o campo Cidade/Estado", true);
        }

        public void ClickAdvanceButton()
        {
            ClickByElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div[2]/div/button[2]", "no botão Avançar");
        }

        public void SelectSubscriptionPlan(SubscriptionPlan plan)
        {
            if (plan == SubscriptionPlan.EssentialYearly || plan == SubscriptionPlan.AdvancedYearly || plan == SubscriptionPlan.ProfessionalYearly)
            {
                ClickByElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div[2]/div[1]/button", "no Switch Anual");
            }

            if (plan == SubscriptionPlan.Free)
            {
                ClickByElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div[2]/div[2]/div[1]/div/div/div[2]/button", "no botão Assinar Iniciante");
            }

            if (plan == SubscriptionPlan.EssentialMonthly)
            {
                ClickByElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div[2]/div[2]/div[2]/div/div/div[2]/button", "no botão Assinar Essencial Mensal");
                WriteCreditCardInfo(false);
            }

            if (plan == SubscriptionPlan.AdvancedMonthly)
            {
                ClickByElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div[2]/div[2]/div[3]/div/div/div[2]/button", "no botão Assinar Avançado Mensal");
                WriteCreditCardInfo(false);
            }

            if (plan == SubscriptionPlan.ProfessionalMonthly)
            {
                ClickByElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div[2]/div[2]/div[4]/div/div/div[2]/button", "no botão Assinar Profissional Mensal");
                WriteCreditCardInfo(false);
            }

            if (plan == SubscriptionPlan.EssentialYearly)
            {
                ClickByElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div[2]/div[2]/div[2]/div/div/div[2]/button", "no botão Assinar Essencial Anual");
                WriteCreditCardInfo(false, true);
            }

            if (plan == SubscriptionPlan.AdvancedYearly)
            {
                ClickByElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div[2]/div[2]/div[3]/div/div/div[2]/button", "no botão Assinar Avançado Anual");
                WriteCreditCardInfo(false, true);
            }

            if (plan == SubscriptionPlan.ProfessionalYearly)
            {
                ClickByElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div[2]/div[2]/div[4]/div/div/div[2]/button", "no botão Assinar Profissional Anual");
                WriteCreditCardInfo(false, true);
            }
        }

        public void ClickConfirmButton()
        {
            ClickByElement("//*[@id=\"checkout\"]/div[2]/button[2]", "no botão Confirmar pagamento");
        }

        private void WriteCreditCardInfo(bool invalidNumber, bool yearly = false)
        {
            ClickByElement("//*[@id=\"checkout\"]/div[1]/div[2]/div[2]/div/div/div/div/div[1]/div", "na opção Cartão de crédito");
            WriteByElement("//input[@id=\"paymentMethod_number\"]",
                invalidNumber ? "4242424242424242" : "4111111111111111", "o campo Número do Cartão");
            WriteByElement("//input[@id=\"paymentMethod_cardholderName\"]", "Teste Teste", "o campo Nome do titular");
            WriteByElement("//input[@id=\"paymentMethod_expirationDate\"]", "062025", "o campo Data de Validade");
            ClickByElement("//input[@id=\"paymentMethod_securityCode\"]", "no campo Código de Segurança");
            WriteByElement("//input[@id=\"paymentMethod_securityCode\"]", "123", "o campo Código de Segurança");

            if (yearly)
            {
                ClickByElement("//input[@id=\"paymentMethod_installments\"]", "a Seleção Parcelamento");
                ClickByElement("/html/body/div[4]/div/div/div/div[2]/div/div/div/div[1]/div", "a Opção 1x");
            }
        }
    }
}