using System;
using System.Text;

public partial class Registro_Simplificado_Listagem : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {

        montaCabecalho();
        dadosCorpo();
        montaRodape();

        //============================================================================
        //graficos - Customize Aqui
        //============================================================================
        string stringDadosGraf;

        // Gasto Total por Placa
        stringDadosGraf = "select Placa, sum(valor) as ValorTotal from Tbl_Abastecimento_Local where Placa<>'' group by Placa ";
        Literal_Bloco1.Text = Monta_Graf_Morris_Donut(stringDadosGraf, "Bloco1_Chart");

        // Gasto Total por Mês
        stringDadosGraf = "select format(Data_Abastecimento,'MM-yyyy') as Mes, sum(valor) as ValorTotal " +
            "from Tbl_Abastecimento_Local group by format(Data_Abastecimento,'MM-yyyy')";
        Literal_Bloco2.Text = Monta_Graf_Morris_Bar(stringDadosGraf, "Bloco2_Chart");
        //============================================================================

    }

    private void montaCabecalho()
    {
        // <!--*******Customização*******-->
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover table-bordered \">" +
            "<thead>" +
            "<tr>" +
            "<th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TALÃO</th>" +
            "<th>DATA</th>" +
            "<th>NOME</th>" +
            "<th>PLACA</th>" +
            "<th>VALOR</th>" +
            "<th>BONIFICADO</th>" +
            "<th>OBS</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        // <!--*******Customização*******-->
        string stringselect = "select ID_Abast, talao, format(Data_Abastecimento,'dd/MM/yyyy') as d1, nome, placa, valor, Bonificado ,Obs " +
                "from Tbl_Abastecimento_Local " +
                "order by talao desc";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            // <!--*******Customização*******-->
            string Coluna0 = Convert.ToString(dados[0]); //id
            string Coluna1 = Convert.ToString(dados[1]);
            string Coluna2 = Convert.ToString(dados[2]);
            string Coluna3 = Convert.ToString(dados[3]);
            string Coluna4 = Convert.ToString(dados[4]);

            decimal valor = Convert.ToDecimal(dados[5]);
            string Coluna5 = "R$ " + valor.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));

            string Coluna6 = Convert.ToString(dados[6]);
            string Coluna7 = Convert.ToString(dados[7]);

            // <!--*******Customização*******-->
            string bt1 = "<a class='w3-btn w3-round w3-hover-blue w3-text-green' href='Abastecimento_Local_Ficha.aspx?v1=" + Coluna0 + "'><i class='fa fa-id-card-o' aria-hidden='true'></i></a>";
            string bt2 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='Excluir(" + Coluna0 + ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";

            // <!--*******Customização*******-->
            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + bt2 + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna6 + "</td>" +
                "<td>" + Coluna7 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);
        }
        ConexaoBancoSQL.fecharConexao();



    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);
        Literal_Tabela.Text = str.ToString();
    }

    private string Monta_Graf_Morris_Donut(string stringselect, string ID_Chart)
    {
        string txtAux = "";
        str.Clear();

        txtAux = "<script type=\"text/javascript\">";
        str.Append(txtAux);

        txtAux = "Morris.Donut({element: '" + ID_Chart + "', data: [";
        str.Append(txtAux);

        //dados
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
        while (dados.Read())
        {
            txtAux = "{label: \"" + Convert.ToString(dados[0]) + "\", value: " + Convert.ToString(dados[1]) + "},";
            str.Append(txtAux);
        }
        ConexaoBancoSQL.fecharConexao();

        txtAux = "]});";
        str.Append(txtAux);

        txtAux = "</script>";
        str.Append(txtAux);

        return str.ToString();

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
            txtAux = "{mes: \"" + Convert.ToString(dados[0]) + "\", valor: " + Convert.ToString(dados[1]) + "},";
            str.Append(txtAux);
        }
        ConexaoBancoSQL.fecharConexao();

        txtAux = "],";
        str.Append(txtAux);

        txtAux = "xkey: 'mes',";
        str.Append(txtAux);

        txtAux = "ykeys: ['valor'],";
        str.Append(txtAux);

        txtAux = "labels: ['Total no Mês']";
        str.Append(txtAux);

        txtAux = "});";
        str.Append(txtAux);

        txtAux = "</script>";
        str.Append(txtAux);

        return str.ToString();

    }
}