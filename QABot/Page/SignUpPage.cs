﻿using OpenQA.Selenium;
using QABot.Core;
using System.Numerics;

namespace QABot.Page
{
    public class SignUpPage : Begin
    {
        public void OpeningSpedySignUp()
        {
            signUpName = GenerateName();
            signUpEmail = GenerateTempEmail();
            signUpFederalTaxNumber = GenerateCnpj();
            signUpPostalCode = GenerateCep();
            driver.Navigate().GoToUrl("https://stage-app.spedy.com.br/signup");
        }

        public void WriteName()
        {
            WriteByElement("//*[@id=\"root\"]/div/form/fieldset/div[1]/input", signUpName, "o campo Seu nome completo");
        }

        public void WriteEmail()
        {
            WriteByElement("//*[@id=\"root\"]/div/form/fieldset/div[2]/input", signUpEmail, "o campo Seu endereço de e-mail");
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
            WaitElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div/div/div[2]/button[2]");
            Wait(1000);
            ClickByElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div/div/div[2]/button[2]", "no botão Já tenho uma empresa");
        }

        public void WriteCompany()
        {
            WriteByElement("//input[@id=\"federalTaxNumber\"]", signUpFederalTaxNumber, "o campo CNPJ");
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
                return;
            }

            WriteByElement("//input[@id=\"address_postalCode\"]", signUpPostalCode, "o campo CEP");
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

        public void SelectSubscriptionPlan(SubscriptionPlan plan, PaymentMethod? paymentMethod)
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
                WriteCreditCardInfo(paymentMethod);
            }

            if (plan == SubscriptionPlan.AdvancedMonthly)
            {
                ClickByElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div[2]/div[2]/div[3]/div/div/div[2]/button", "no botão Assinar Avançado Mensal");
                WriteCreditCardInfo(paymentMethod);
            }

            if (plan == SubscriptionPlan.ProfessionalMonthly)
            {
                ClickByElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div[2]/div[2]/div[4]/div/div/div[2]/button", "no botão Assinar Profissional Mensal");
                WriteCreditCardInfo(paymentMethod);
            }

            if (plan == SubscriptionPlan.EssentialYearly)
            {
                ClickByElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div[2]/div[2]/div[2]/div/div/div[2]/button", "no botão Assinar Essencial Anual");
                WriteCreditCardInfo(paymentMethod, true);
            }

            if (plan == SubscriptionPlan.AdvancedYearly)
            {
                ClickByElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div[2]/div[2]/div[3]/div/div/div[2]/button", "no botão Assinar Avançado Anual");
                WriteCreditCardInfo(paymentMethod, true);
            }

            if (plan == SubscriptionPlan.ProfessionalYearly)
            {
                ClickByElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div[2]/div[2]/div[4]/div/div/div[2]/button", "no botão Assinar Profissional Anual");
                WriteCreditCardInfo(paymentMethod, true);
            }

            ClickConfirmButton(plan);
        }


        public void ClickDashBoardButton()
        {
            WaitElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div/div[2]/button");
            Wait(1000);
            ClickByElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div/div[2]/button", "no botão Ir para o dashboard");
        }

        private void ClickConfirmButton(SubscriptionPlan plan)
        {
            if (plan == SubscriptionPlan.Free)
            {
                return;
            }

            ClickByElement("//*[@id=\"checkout\"]/div[2]/button[2]", "no botão Confirmar pagamento");
        }

        private void WriteCreditCardInfo(PaymentMethod? paymentMethod, bool yearly = false)
        {
            var hasOnePaymentMethod = ValidateOneFlagSet(paymentMethod);

            if (!hasOnePaymentMethod)
            {
                ClickByElement("//*[@id=\"checkout\"]/div[1]/div[2]/div[2]/div/div/div/div/div[1]/div", "na opção Cartão de crédito");
            }

            Wait(1000);
            WriteByElement("//input[@id=\"paymentMethod_number\"]", "4111111111111111", "o campo Número do Cartão");
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

        private static bool ValidateOneFlagSet(PaymentMethod? paymentMethod)
        {
            return BitOperations.PopCount((ulong)paymentMethod!) == 1;
        }
    }
}