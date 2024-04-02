using QABot.Core;

namespace QABot.Page
{
    public class ProductPage : Begin
    {
        public void Login()
        {
            LoginSpedy();
        }

        public void SelectAccount()
        {
            SearchAccount();
        }

        public void New(InvoiceModel invoiceModel)
        {
            WaitElement("//a[@href=\"/p/products\"]");
            ClickByElement("//a[@href=\"/p/products\"]", "no aba Produtos");
            CreateNew(invoiceModel);
        }

        private void CreateNew(InvoiceModel invoiceModel)
        {
            ClickByElement("//*[@id=\"root\"]/section/section/main/div[1]/div[2]/div/div/button", "no botão + Novo");
            WriteByElement("//input[@id=\"name\"]", "Produto Teste 112", "o campo Nome");
            ClearValue("//input[@id=\"price\"]");
            WriteByElement("//input[@id=\"price\"]", "2", "o campo Preço da venda");

            if (invoiceModel != InvoiceModel.ServiceInvoice)
            {
                DropDownMenu("/html/body/div[3]/div/div[2]/div/div/div[2]/form/div[2]/div[1]/div/div[2]/div/div/div",
                    invoiceModel == InvoiceModel.ProductInvoice ? "NF-e" : "Split", "Modelo NF");
            }

            ClickByElement("/html/body/div[3]/div/div[2]/div/div/div[2]/div/div/button[2]/span", "no botão Salvar");
        }

        public void EditNew()
        {
            ClickByElement("//*[@id=\"root\"]/section/section/main/div[2]/div/div/div/div/div/div/div/div/div/div/table/tbody/tr/td[5]/span/button[1]", "no botão Editar");
            ClearValue("//input[@id=\"name\"]");
            WriteByElement("//input[@id=\"name\"]", "Produto Editado", "o campo Nome");
            ClearValue("//input[@id=\"price\"]");
            WriteByElement("//input[@id=\"price\"]", "10", "o campo Preço da venda");
            ClickByElement("/html/body/div[4]/div/div[2]/div/div/div[2]/div/div/button[2]/span", "no botão Salvar");
        }
    }
}
