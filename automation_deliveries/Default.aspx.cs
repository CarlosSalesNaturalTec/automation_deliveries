using System;
using System.Web.UI;

namespace automation_deliveries
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_data.Text = DateTime.Today.ToString("dd/MM/yyyy");
                Id_Funcionario();
            }
        }

        private void Id_Funcionario()
        {
            //email utilizado no login
            string str1 = Context.User.Identity.Name;
            string str2 = str1.Substring(9);   // email do funcionário

            //Busca ID do funcionário em banco de dados
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select("select ID_Motoboy, Nome from Tbl_Motoboys where email = '" + str2 + "'");

            string str3 = "", str4 = "";

            while (dados.Read())
            {
                str3 = Convert.ToString(dados[0]);  // ID
                str4 = Convert.ToString(dados[1]);  // nome do funcionário
            }

            lbl_id_funcionario.Text = str4;

            //armazena id em variável de seção que irá se persistir entre as janelas do browser
            Session["ID_Funcionario"] = str3;
        }

        private void entregasdoDia()
        {
            // string com data selecionada - máscara padrão SQL
            IFormatProvider culture = new System.Globalization.CultureInfo("pt-BR", true);
            DateTime dt2 = DateTime.Parse(lbl_data.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            string date_formated = dt2.ToString("yyyy-MM-dd");
            
            string stringSelect = @"select Tbl_Entregas.ID_Motoboy, Tbl_Motoboys.Nome, Tbl_Entregas.Id_Entrega, Tbl_Entregas.Nome_Destinatario, " +
                    " Tbl_Entregas.Endereco, Tbl_Entregas.Bairro, Tbl_Entregas.Cidade, " +
                    " Tbl_Entregas.Telefone, Tbl_Entregas.Data_Encomenda, Tbl_Entregas.Cod_Encomenda from Tbl_Entregas " +
                    " INNER JOIN Tbl_Motoboys ON Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy " +
                    " where Tbl_Entregas.ID_Motoboy = " + Session["ID_Cliente"].ToString() +
                    " and Tbl_Entregas.Data_Encomenda = '" + date_formated + "'" +
                    " order by Tbl_Motoboys.Nome, Tbl_Entregas.Nome_Destinatario";
                        
        }

    }
}