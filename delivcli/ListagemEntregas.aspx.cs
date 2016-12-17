using System;
using System.Text;
using System.Web.UI;

namespace delivcli
{
    public partial class ListagemEntregas : Page
    {

        StringBuilder str = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // tenta identificar se houve login. caso contrário vai para página de erro
                string v_id_cli = Session["Cli_ID"].ToString();

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
                "<th>DESTINATÁRIO</th>" +
                "<th>BAIRRO</th>" +
                "<th>ENTREGADOR</th>" +
                "<th>STATUS</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>";
            str.Clear();
            str.Append(stringcomaspas);
        }

        private void dadosCorpo()
        {
            string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
            string stringselect = @"select Tbl_Motoboys.Nome, Tbl_Entregas.Nome_Destinatario, Tbl_Entregas.Status_Entrega, " +
                    " Tbl_Entregas.ID_Entrega, Tbl_Entregas.Bairro, Tbl_Entregas.ID_Motoboy " +
                    " from Tbl_Entregas " +
                    " INNER JOIN Tbl_Motoboys ON Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy " +
                    " where Tbl_Entregas.ID_Cliente = " + Session["Cli_ID"].ToString() +
                    " and format(Tbl_Entregas.Data_Encomenda,'yyyy-MM-dd') ='" + datastatus + "'" +
                    " order by Tbl_Entregas.Nome_Destinatario";

            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                string linkUrl = "<a href=\"FichaEntregador.aspx?ID=" + Convert.ToString(dados[5]) + "\" target=\"_parent\">";

                string colunaEntregador = linkUrl + Convert.ToString(dados[0]) + "</a>";
                string colunaDestinatario = Convert.ToString(dados[1]);
                string colunaStatus = Convert.ToString(dados[2]);
                string colunaBairro = Convert.ToString(dados[4]);
                string colunaStatusFormat = "";

                switch (colunaStatus)
                {
                    case "ENTREGA REALIZADA":
                        colunaStatusFormat = "<p class=\"text-success\">";
                        break;
                    case "EM ANDAMENTO":
                        colunaStatusFormat = "<p class=\"text-info\">";
                        break;
                    case "EM ABERTO":
                        colunaStatusFormat = "<p class=\"text-primary\">";
                        break;
                    default:
                        colunaStatusFormat = "<p class=\"text-danger\">";        
                        break;
                }

                string colunaStatusFormat1 = "</p>";

                linkUrl = "<a href=\"DetalhesEntrega.aspx" + "?IDEnt=" + Convert.ToString(dados[3]) +  "\" target=\"_parent\">";

                string stringcomaspas = "<tr>" +
                    "<td>" + colunaDestinatario + "</td>" +
                    "<td>" + colunaBairro + "</td>" +
                    "<td>" + colunaEntregador + "</td>" +
                    "<td>" + linkUrl + colunaStatusFormat + colunaStatus + colunaStatusFormat1 + "</a></td>" +
                    "</tr>";

                str.Append(stringcomaspas);
            }
            ConexaoBancoSQL.fecharConexao();
        }

        private void montaRodape()
        {
            string footer = "</tbody></table>";
            str.Append(footer);
        }

    }
}