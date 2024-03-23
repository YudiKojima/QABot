using QABot.Core;

namespace QABot.Page
{
    public class SignUpPage : Begin
    {
        public void WriteName()
        {
            WriteByElement("//*[@id=\"root\"]/div/form/fieldset/div[1]/input", "Bot", "o campo Seu nome completo");
        }

        public void WriteEmail()
        {
            WriteByElement("//*[@id=\"root\"]/div/form/fieldset/div[2]/input", "Teste@com.br", "o campo Seu endereço de e-mail");
        }

        public void WritePhoneNumber()
        {
            WriteByElement("//*[@id=\"root\"]/div/form/fieldset/div[3]/input", "66666666666", "o campo Celular");
        }

        public void WritePassword()
        {
            WriteByElement("//*[@id=\"input-visible\"]", "teste123", "o campo Sua senha");
        }

        public void ClickCheckBox()
        {
            ClickByElement("//*[@id=\"root\"]/div/form/div[2]/input", "no checkbox Termos de uso");
        }
    }
}