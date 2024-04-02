using NUnit.Framework;
using QABot.Page;

namespace QABot.Test
{
    public class ProductTest : ProductPage
    {
        [Test]
        public void Create()
        {
            Login();
            SelectAccount();
            New(InvoiceModel.ProductInvoice);
        }

        [Test]
        public void Edit()
        {
            Create();
            EditNew();
        }
    }
}
