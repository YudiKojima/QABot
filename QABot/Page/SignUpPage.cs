using QABot.Core;

namespace QABot.Page
{
    public class SignUpPage : Begin
    {
        public void WriteName()
        {
            WriteByName("name", "Bot");
        }

        public void WriteEmail()
        {
            WriteByName("email", "X");
        }

        public void WritePhoneNumber()
        {
            WriteByName("phoneNumber", "66666666666");
        }
        
        public void WritePassword()
        {
            WriteByName("password", "teste123");
        }

        public void ClickCheckBox()
        {
            ClickByName("checkbox");
        }
    }
}