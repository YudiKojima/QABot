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

            //var legalName = driver.FindElement(By.XPath("//input[@id=\"legalName\"]"));
            //var fantasyName = driver.FindElement(By.XPath("//input[@id=\"name\"]"));

            //if (legalName.GetAttribute("value") != null && fantasyName.GetAttribute("value") != null)
            //{
            //    return;
            //}

            WriteByElement("//input[@id=\"legalName\"]", "razao social teste", "o campo Razão Social");
            WriteByElement("//input[@id=\"name\"]", "nome fantasia", "o campo Nome fantasia");
        }

        public void WriteAddress()
        {
            //var cep = driver.FindElement(By.XPath("//input[@id=\"address_postalCode\"]"));

            //if (cep.GetAttribute("value") != null)
            //{
            //    return;
            //}

            WriteByElement("//input[@id=\"address_postalCode\"]", postalCode, "o campo CEP");
            Wait(4000);

            //var street = driver.FindElement(By.XPath("//input[@id=\"address_street\"]"));

            //if (street.GetAttribute("value") != null)
            //{
            //    return;
            //}

            WriteByElement("//input[@id=\"address_street\"]", "rua teste", "o campo Logradouro");
            WriteByElement("//input[@id=\"address_number\"]", "123", "o campo Número");
            WriteByElement("//input[@id=\"address_district\"]", "bairro teste", "o campo Bairro");
            WriteByElement("//input[@id=\"address_city\"]", "Cuiaba", "o campo Cidade/Estado", true);
        }

        public void ClickAdvanceeButton()
        {
            ClickByElement("/html/body/div[3]/div/div[2]/div/div[2]/div/div[2]/div/button[2]", "no botão Avançar");
        }
    }
}