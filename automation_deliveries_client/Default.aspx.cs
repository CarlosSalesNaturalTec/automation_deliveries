using System;
using System.Web.UI;

namespace automation_deliveries_client
{
    public partial class _Default : Page
    {
        // ID do cliente
        string ID_Cli = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_data.Text = DateTime.Today.ToString("dd/MM/yyyy");
                Id_Cliente();
                entregasdia();
                funcionariosemcampo();
            }
        }

        private void Id_Cliente()
        {
            try
            {
                //email utilizado no login
                string str1 = Context.User.Identity.Name;
                string str2 = str1.Substring(9);
                string str3 = "";

                //Busca ID do cliente em banco de dados
                OperacaoBanco operacao = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao.Select("select ID_Cliente from tbl_clientes where email = '" + str2 + "'");
                while (dados.Read()) { str3 = Convert.ToString(dados[0]); }
                ID_Cli = str3;
            }
            catch (Exception)
            {
                lbl_msg.Text = "NÃO FOI POSSÍVEL CARREGAR ID DO CLIENTE";
                throw;
            }
            
        }

        public void entregasdia()
        {
            try
            {
                // string data formatada
                IFormatProvider culture = new System.Globalization.CultureInfo("pt-BR", true);
                DateTime dt2 = DateTime.Parse(lbl_data.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                string date_formated = dt2.ToString("yyyy-MM-dd");

                // total de entregas no dia
                string stringselect = "select count(*) as totalregistros from tbl_entregas where id_cliente = " + ID_Cli + " and Data_Encomenda = '" + date_formated + "'";
                OperacaoBanco operacao = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

                while (dados.Read())
                {
                    lbl_total_entregas_dia.Text = Convert.ToString(dados[0]);
                }
                ConexaoBancoSQL.fecharConexao();
            }
            catch (Exception)
            {
                lbl_total_entregas_dia.Text = "9999";
                lbl_msg.Text = lbl_msg.Text + " - ERRO AO CALCULAR TOTAL DE ENTREGAS NO DIA";
                throw;
            }
        }

        private void funcionariosemcampo()
        {
            // total de funcionários
            try
            {
                string t1 = "0";
                string stringselect = "select count(*) as totalregistros from tbl_motoboys where id_cliente = " + ID_Cli ;
                OperacaoBanco operacao = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
                while (dados.Read())
                {
                    t1 = Convert.ToString(dados[0]);
                }
                ConexaoBancoSQL.fecharConexao();
                lbl_msg.Text = "total de funcionários: " + t1;
            }
            catch (Exception)
            {
                lbl_msg.Text = lbl_msg.Text + " - ERRO AO CALCULAR QUANT TOTAL DE FUNCIONARIOS!";
                throw;
            }

            // total de funcionários que já realizaram entregas no dia
            try
            {
                // string data formatada
                IFormatProvider culture = new System.Globalization.CultureInfo("pt-BR", true);
                DateTime dt2 = DateTime.Parse(lbl_data.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                string date_formated = dt2.ToString("yyyy-MM-dd");

                // string lista de funcionários que já efetuaram entregas no dia
                string stringselect = "select ID_Motoboy from tbl_entregas " +
                        " where id_cliente = " + ID_Cli + " and Entregue = 1 and Data_Entrega = '" + date_formated + "' group by ID_Motoboy";

                int contador = 0;

                OperacaoBanco operacao = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
                while (dados.Read())
                {
                    contador = contador + 1;
                }
                ConexaoBancoSQL.fecharConexao();
                lbl_msg.Text = lbl_msg.Text + " / quant func. realizaram entregas:" + contador.ToString();
            }
            catch (Exception)
            {
                lbl_msg.Text = lbl_msg.Text + " - ERRO AO CALCULAR QUANT TOTAL DE FUNCIONARIOS QUE EFETUARAM ENTREGA!";
                throw;
            }
        }
    }
}