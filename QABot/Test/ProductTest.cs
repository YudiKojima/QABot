using NUnit.Framework;
using QABot.Page;

namespace QABot.Test
{
    public class ProductTest : ProductPage
    {
        [Test]
        public void CreateProduct()
        {
            LoginSpedy();
            SearchAccount();
            NewProduct(InvoiceModel.ProductInvoice);
        }
    }
}
