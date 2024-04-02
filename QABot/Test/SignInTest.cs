using NUnit.Framework;
using QABot.Page;

namespace QABot.Test
{
    public class SignInTest : SignInPage
    {
        [Test]
        public void SignIn()
        {
            Login();
        }
    }
}
