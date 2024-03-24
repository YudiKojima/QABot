using QABot.Core;

namespace QABot.Page
{
    public class SignInPage : Begin
    {
        public void WriteEmail()
        {
            WriteByElement("//input[@name=\"email\"]", "marcos.silva@spedy.com.br", "o campo Seu endereço de e-mail");
        }

        public void WritePassword()
        {
            WriteByElement("//input[@name=\"password\"]", "teste123", "o campo Sua senha");
        }

        public void ClickAccessButton()
        {
            ClickByElement("//*[@id=\"root\"]/div/form/button", "no botão Acessar");
        }
    }
}
