using QABot.Core;

namespace QABot.Page
{
    public class ProductPage : Begin
    {
        public void LoginSpedy()
        {
            SignInSpedy();
        }

        public void SearchAccount()
        {
            WaitElement("//input[@id=\"filterText\"]");
            WriteByElement("//input[@id=\"filterText\"]", "nfe", "o campo Pesquisar conta...");
            Wait(2000);
            ValidateElementExist("//*[@id=\"root\"]/section/section/main/div[2]/div/div/div/div/div/div/div/div/div/div/table/tbody/tr[2]/td[1]/div/div[1]");
            DropDownMenu("//*[@id=\"root\"]/section/section/main/div[2]/div/div/div/div/div/div/div/div/div/div/table/tbody/tr[2]/td[6]/i",
                "Acessar conta", "Opções");
        }

        public void NewProduct(InvoiceModel invoiceModel)
        {
            WaitElement("//a[@href=\"/p/products\"]");
            ClickByElement("//a[@href=\"/p/products\"]", "no aba Produtos");
            CreateNewProduct(invoiceModel);
        }

        private void CreateNewProduct(InvoiceModel invoiceModel)
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
    }
}
