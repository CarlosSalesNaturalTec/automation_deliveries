using System;
using System.Text;

namespace PainelCliente_01
{
    public partial class Entregadores : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                montaCabecalho();
                dadosCorpo();
                montaRodape();

                Literal1.Text = str.ToString();
            }
        }

        private void montaCabecalho()
        {
            string stringcomaspas = "<table id=\"tabelaEnt\" class=\"table table-striped table-hover \">" +
                "<thead>" +
                "<tr>" +
                "<th>NOME</th>" +
                "<th>VEICULO</th>" +
                "<th>PLACA</th>" +
                "<th>TELEFONE</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>";
            str.Clear();
            str.Append(stringcomaspas);
        }

        private void dadosCorpo()
        {
            string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
            string stringselect = @"select Nome, Veiculo, Placa, Telefone, ID_Motoboy " +
                    " from Tbl_Motoboys " +
                    " where ID_Cliente = " + Session["Cli_ID"].ToString() +
                    " order by Nome";

            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                string linkUrl = "<a href=\"EntregadorFicha.aspx?IDEnt=" + Convert.ToString(dados[4]) + "\" target=\"_self\">";

                string Coluna1 = linkUrl + Convert.ToString(dados[0]) + "</a>";
                string Coluna2 = Convert.ToString(dados[1]);
                string Coluna3 = Convert.ToString(dados[2]);
                string Coluna4 = Convert.ToString(dados[3]);

                string stringcomaspas = "<tr>" +
                    "<td>" + Coluna1 + "</td>" +
                    "<td>" + Coluna2 + "</td>" +
                    "<td>" + Coluna3 + "</td>" +
                    "<td>" + Coluna4 + "</td>" +
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