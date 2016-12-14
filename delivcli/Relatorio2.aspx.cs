using System;
using System.Text;

namespace delivcli
{
    public partial class Relatorio2 : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                txtPer1.Text = DateTime.Today.ToString("dd/MM/yyyy");
                TxtPer2.Text = DateTime.Today.ToString("dd/MM/yyyy");

                montaCabecalho();
                dadosCorpo();
                montaRodape();
                Literal1.Text = str.ToString();
            }
        }

        private void montaCabecalho()
        {
            string stringcomaspas = "<table class=\"table table-striped table-hover \">" +
                "<thead>" +
                    "<tr>" +
                        "<th>Entregador</th>" +
                        "<th>Total de Entregas no Período</th>" +
                        "<th>Total Entregador</th>" +
                        "<th>% Geral</th>" +
                        "<th>Entregues</th>" +
                        "<th>% Performance</th>" +
                    "</tr>" +
                "</thead>" +
                "<tbody>";
            str.Clear();
            str.Append(stringcomaspas);
        }

        private void dadosCorpo()
        {
            string stringselect = "select Nome, ID_Motoboy from Tbl_Motoboys where ID_Cliente = " + Session["Cli_ID"].ToString() + " order by Nome";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            string T1 = TotalEntregas();

            while (dados.Read())
            {
                string Entregador = Convert.ToString(dados[0]);
                string T2 = TotalEntregador(Convert.ToString(dados[1]));

                if (T2 == "0") { continue; }

                string T3 = TotalEntregues(Convert.ToString(dados[1]));

                double percent1 = (Convert.ToDouble(T2) / Convert.ToDouble(T1)) * 100;
                double percent2 = (Convert.ToDouble(T3) / Convert.ToDouble(T2)) * 100;

                string stringcomaspas = "<tr>" +
                                           "<td>" + Entregador + "</td>" +
                                           "<td>" + T1 + "</td>" +
                                           "<td>" + T2 + "</td>" +
                                           "<td>" + percent1.ToString("#,0.00") + "</td>" +
                                           "<td>" + T3 + "</td>" +
                                           "<td>" + percent2.ToString("#,0.00") + "</td>" +
                                        "</tr>";
                str.Append(stringcomaspas);
            }
            ConexaoBancoSQL.fecharConexao();
        }

        private string TotalEntregas()
        {
            string TotalGeralEntregas = "0";
            string stringselect = "select COUNT(Tbl_Entregas.ID_Entrega) as TotalGeralEntregas " +
                                "from Tbl_Entregas  " +
                                "where Tbl_Entregas.ID_Cliente = " + Session["Cli_ID"].ToString() + " and " +
                                "format(Tbl_Entregas.Data_Encomenda,'dd/MM/yyyy') >='" + txtPer1.Text + "' " +
                                "and format(Tbl_Entregas.Data_Encomenda,'dd/MM/yyyy') <='" + TxtPer2.Text + "'";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                TotalGeralEntregas = Convert.ToString(dados[0]);
            }
            ConexaoBancoSQL.fecharConexao();

            return TotalGeralEntregas;
        }

        private string TotalEntregador(string id)
        {
            string TotalGeralEntregador = "0";
            string stringselect = "select COUNT(Tbl_Entregas.ID_Entrega) as TotalGeralEntregas " +
                                "from Tbl_Entregas  " +
                                "where Tbl_Entregas.ID_Cliente = " + Session["Cli_ID"].ToString() + " and " +
                                "Tbl_Entregas.ID_Motoboy = " + id + " and " +
                                "format(Tbl_Entregas.Data_Encomenda,'dd/MM/yyyy') >='" + txtPer1.Text + "' " +
                                "and format(Tbl_Entregas.Data_Encomenda,'dd/MM/yyyy') <='" + TxtPer2.Text + "'";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                TotalGeralEntregador = Convert.ToString(dados[0]);
            }
            ConexaoBancoSQL.fecharConexao();

            return TotalGeralEntregador;
        }

        private string TotalEntregues(string id)
        {
            string TotalGeralEntregues = "1";
            string stringselect = "select COUNT(Tbl_Entregas.ID_Entrega) as TotalGeralEntregas " +
                                "from Tbl_Entregas  " +
                                "where Tbl_Entregas.ID_Motoboy = " + id + " and " +
                                "Tbl_Entregas.Entregue = 1 and " +
                                "format(Tbl_Entregas.Data_Encomenda,'dd/MM/yyyy') >='" + txtPer1.Text + "' " +
                                "and format(Tbl_Entregas.Data_Encomenda,'dd/MM/yyyy') <='" + TxtPer2.Text + "'";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                TotalGeralEntregues = Convert.ToString(dados[0]);
            }
            ConexaoBancoSQL.fecharConexao();

            return TotalGeralEntregues;
        }

        private void montaRodape()
        {
            string footer = "</tbody></table>";
            str.Append(footer);
        }

        protected void txtPer1_TextChanged(object sender, EventArgs e)
        {
            montaCabecalho();
            dadosCorpo();
            montaRodape();
            Literal1.Text = str.ToString();
        }

        protected void TxtPer2_TextChanged(object sender, EventArgs e)
        {
            montaCabecalho();
            dadosCorpo();
            montaRodape();
            Literal1.Text = str.ToString();
        }
    }

}