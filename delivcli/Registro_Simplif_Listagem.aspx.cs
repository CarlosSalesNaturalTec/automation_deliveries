using System;
using System.Globalization;
using System.Text;


namespace delivcli
{
    public partial class Registro_Simplif_Listagem : System.Web.UI.Page
    {

        StringBuilder str = new StringBuilder();
        string idCli;

        protected void Page_Load(object sender, EventArgs e)
        {
            idCli = Session["Cli_ID"].ToString();

            montaCabecalho();
            dadosCorpo();
            montaRodape();

        }

        private void montaCabecalho()
        {
            // <!--*******Customização*******-->
            string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover table-bordered \">" +
                "<thead>" +
                "<tr>" +
                "<th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ORDEM</th>" +
                "<th>MOTOBOY</th>" +
                "<th>DATA</th>" +
                "<th>QUANT.ENTREGAS</th>" +
                "<th>REALIZADAS</th>" +
                "<th>DEVOLVIDAS</th>" +
                "<th>OBSERVAÇÕES</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>";
            str.Clear();
            str.Append(stringcomaspas);
        }

        private void dadosCorpo()
        {
            // <!--*******Customização*******-->
            string stringselect = "select ID_Entrega, Motoboy , format(DataEntrega ,'dd/MM/yyyy') as d1, Quatidade , Entregues , Realizadas , Observacoes " +
                    "from Tbl_Entrega_Simplficada " +
                    "where ID_Cliente = " + idCli +
                    " order by DataEntrega";

            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
            int ordem = 1;

            while (dados.Read())
            {
                // <!--*******Customização*******-->
                string Coluna0 = Convert.ToString(dados[0]); //id
                string Coluna1 = Convert.ToString(dados[1]);
                string Coluna2 = Convert.ToString(dados[2]);
                string Coluna3 = Convert.ToString(dados[3]);
                string Coluna4 = Convert.ToString(dados[4]);
                string Coluna5 = Convert.ToString(dados[5]);
                string Coluna6 = Convert.ToString(dados[6]);

                // <!--*******Customização*******-->
                string bt1 = "<a class='w3-btn w3-round w3-hover-blue w3-text-green' href='Registro_Simplif_Ficha.aspx?v1=" + Coluna0 + "'><i class='fa fa-id-card-o' aria-hidden='true'></i></a>";
                string bt2 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='Excluir(" + Coluna0 + ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";

                // <!--*******Customização*******-->
                string stringcomaspas = "<tr>" +
                    "<td>" + bt1 + bt2 + ordem + "</td>" +
                    "<td>" + Coluna1 + "</td>" +
                    "<td>" + Coluna2 + "</td>" +
                    "<td>" + Coluna3 + "</td>" +
                    "<td>" + Coluna4 + "</td>" +
                    "<td>" + Coluna5 + "</td>" +
                    "<td>" + Coluna6 + "</td>" +
                    "</tr>";
                str.Append(stringcomaspas);
                ordem++;
            }
            ConexaoBancoSQL.fecharConexao();
        }

        private void montaRodape()
        {
            string footer = "</tbody></table>";
            str.Append(footer);
            Literal_Tabela.Text = str.ToString();
        }


    }
}