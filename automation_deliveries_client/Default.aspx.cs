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
                lbl_total_entregas_dia.Text = "999";
            }
        }

        public void Total_Entregas()
        {
            string stringSelect = @"SELECT COUNT(*) AS totalderegistros FROM Tbl_Entregas where " +
                "ID_Cliente= " + Session["ID_Cliente"].ToString() + " and Data_Encomenda=null";

            // total de entregas cadastradas no dia
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringSelect);
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
            lbl_total_entregas_dia.Text = totalderegistros;
        }
    }
}