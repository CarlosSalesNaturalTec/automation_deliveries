using System;
using System.Text;

namespace delivcli
{
    public partial class Relatorio2 : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        string v_id_cli = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                txtPer1.Text = DateTime.Today.ToString("dd/MM/yyyy");
                TxtPer2.Text = DateTime.Today.ToString("dd/MM/yyyy");


                // tenta identificar se houve login. caso contrário vai para página de erro
                v_id_cli = Session["Cli_ID"].ToString();

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
                        "<th>Total de Entregas Cadastradas</th>" +
                        "<th>Total de Entregas Realizadas</th>" +
                        "<th>Percentual</th>" +
                    "</tr>" +
                "</thead>" +
                "<tbody>";
            str.Clear();
            str.Append(stringcomaspas);
        }

        private void dadosCorpo()
        {
            string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
            string stringselect = @"select Tbl_Motoboys.Nome, COUNT(Tbl_Entregas.ID_Entrega) as TotalEntregas " +
                                    "from Tbl_Entregas " +
                                    "INNER JOIN Tbl_Motoboys ON Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy " +
                                    "where Tbl_Entregas.ID_Cliente = " + v_id_cli + " and " +
                                    "format(Tbl_Entregas.Data_Encomenda,'yyyy-MM-dd') ='" + datastatus + "' " +
                                    "group by Tbl_Motoboys.Nome";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                string colunaEntregador = Convert.ToString(dados[0]);
                string colunaTotalEntregador = Convert.ToString(dados[1]);

                double percentual = (Convert.ToDouble(colunaTotalEntregador) / Convert.ToDouble(TotalEntregas())) * 100;

                string stringcomaspas = "<tr>" +
                                           "<td>" + colunaEntregador + "</td>" +
                                           "<td>" + TotalEntregas() + "</td>" +
                                           "<td>" + colunaTotalEntregador + "</td>" +
                                           "<td>" + percentual.ToString("#,#.00") + "</td>" +
                                        "</tr>";
                str.Append(stringcomaspas);
            }
            ConexaoBancoSQL.fecharConexao();
        }

        private string TotalEntregas()
        {
            string TotalGeralEntregas = "";
            string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
            string stringselect = "select COUNT(Tbl_Entregas.ID_Entrega) as TotalGeralEntregas " +
                                "from Tbl_Entregas  " +
                                "where Tbl_Entregas.ID_Cliente = " + v_id_cli + " and " +
                                "format(Tbl_Entregas.Data_Encomenda,'yyyy-MM-dd') ='" + datastatus + "'";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                TotalGeralEntregas = Convert.ToString(dados[0]);
            }
            ConexaoBancoSQL.fecharConexao();

            return TotalGeralEntregas;
        }

        private void montaRodape()
        {
            string footer = "</tbody></table>";
            str.Append(footer);
        }

    }

}