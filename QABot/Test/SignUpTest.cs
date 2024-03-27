using NUnit.Framework;
using QABot.Page;

namespace QABot.Test
{
    public class SignUpTest : SignUpPage
    {
        [Test]
        public void SignUp()
        {
            OpeningSpedySignUp();
            WriteName();
            WriteEmail();
            WritePhoneNumber();
            WritePassword();
            ClickCheckBox();
            ClickAccessButton();
            ClickContinueButton();
            WriteCompany();
            WriteAddress();
            ClickAdvanceButton();
            SelectSubscriptionPlan(SubscriptionPlan.EssentialMonthly);
            ClickConfirmButton();
            ClickDashBoardButton();
        }
    }
}
