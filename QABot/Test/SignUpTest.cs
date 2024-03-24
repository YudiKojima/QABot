using NUnit.Framework;
using QABot.Page;

namespace QABot.Test
{
    public class SignUpTest : SignUpPage
    {
        [Test]
        public void SignUp()
        {
            WriteName();
            WriteEmail();
            WritePhoneNumber();
            WritePassword();
            ClickCheckBox();
            ClickAccessButton();
            ClickContinueButton();
            WriteCompany();
            WriteAddress();
            ClickAdvanceeButton();
        }
    }
}
