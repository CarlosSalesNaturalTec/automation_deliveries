using System;
using System.Web.UI;

namespace automation_deliveries_client
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_data.Text = DateTime.Today.ToString("dd/MM/yyyy");
            }
        }

        private void Funcionarios_em_Campo()
        {
            // string data local
            IFormatProvider culture = new System.Globalization.CultureInfo("pt-BR", true);
            DateTime dt2 = DateTime.Parse(lbl_data.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            string date_formated = dt2.ToString("yyyy-MM-dd");

            // total de funcionarios cadastrados
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(@"SELECT COUNT(*) AS totalderegistros FROM Tbl_Motoboys" +
                " where ID_Cliente = " + Session["ID_Cliente"].ToString());
            String totalderegistros = "";
            try
            {
                while (dados.Read())
                {
                    totalderegistros = Convert.ToString(dados[0]);
                }
            }
            catch (Exception)
            {
                throw;
            }
            ConexaoBancoSQL.fecharConexao();
        }
    }
}