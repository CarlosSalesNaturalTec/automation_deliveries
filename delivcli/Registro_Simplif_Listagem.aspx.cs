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

            //============================================================================
            //graficos - Customize Aqui
            //============================================================================
            string stringDadosGraf;

            // Total de Entregas por Motoboy
            stringDadosGraf = "select Motoboy, sum(Quantidade ) as T1, sum(Entregues) as T2 " +
                "from Tbl_Entrega_Simplficada group by Motoboy";
            Literal_Bloco1.Text = Monta_Graf_Morris_Bar(stringDadosGraf, "Bloco1_Chart");
            //============================================================================

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
                "<th>ENTREGUES</th>" +
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
            string stringselect = "select ID_Entrega, Motoboy , format(DataEntrega ,'dd/MM/yyyy') as d1, Quantidade  , Entregues , Devolvidas , Observacoes " +
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

        private string Monta_Graf_Morris_Bar(string stringselect, string ID_Chart)
        {
            string txtAux = "";
            str.Clear();

            txtAux = "<script type=\"text/javascript\">";
            str.Append(txtAux);

            txtAux = "Morris.Bar({element: '" + ID_Chart + "', data: [";
            str.Append(txtAux);

            //dados
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
            while (dados.Read())
            {

                var nomeMotoboy = "";
                int v1 = Convert.ToString(dados[0]).Length;
                if (Convert.ToString(dados[0]).Length > 10)
                {
                    nomeMotoboy = Convert.ToString(dados[0]).Substring(0, 9);
                }else {
                    nomeMotoboy = Convert.ToString(dados[0]).Substring(0, v1);
                }

                txtAux = "{serie: \"" + nomeMotoboy + "\", valor1: " + Convert.ToString(dados[1]) + ", valor2:" + Convert.ToString(dados[2]) + "},";
                str.Append(txtAux);
            }
            ConexaoBancoSQL.fecharConexao();

            txtAux = "],";
            str.Append(txtAux);

            txtAux = "xkey: 'serie',";
            str.Append(txtAux);

            txtAux = "ykeys: ['valor1','valor2'],";
            str.Append(txtAux);

            txtAux = "labels: ['Total de Entregas','Devolvidas'],";
            str.Append(txtAux);

            txtAux = "gridTextSize: 8";
            str.Append(txtAux);

            txtAux = "});";
            str.Append(txtAux);

            txtAux = "</script>";
            str.Append(txtAux);

            return str.ToString();

        }


    }
}