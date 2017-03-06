using System;
using System.Globalization;
using System.Text;

public partial class Abastecimento_RelatorioOK : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    string placa = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            placa = Request.QueryString["p1"];
            Literal_Placa.Text = "Placa : " + placa;

            montaCabecalho();
            dadosCorpo();
            montaRodape();

            Literal_Dados.Text = str.ToString();
        }
    }

    private void montaCabecalho()
    {
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover \">" +
            "<thead>" +
            "<tr>" +
            "<th>DATA</th>" +
            "<th>MOTORISTA</th>" +
            "<th style=\"text-align:right\">KM</th>" +
            "<th style=\"text-align:right\">DIST.</th>" +
            "<th style=\"text-align:right\">VALOR</th>" +
            "<th style=\"text-align:right\">INDICE</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        String stringselect = "select format(DataAutoriza,'dd/MM/yyyy') as DataOper," +
                " Nome, Kilometragem, Valor" +
                " from Tbl_Abastecimentos" +
                " where Placa = '"  +  placa + "'" +
                " order by DataAutoriza ";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        int distAnterior = 0;
        int dist = 0;

        while (dados.Read())
        {
            string Coluna0 = Convert.ToString(dados[0]);    //data
            string Coluna1 = Convert.ToString(dados[1]);    //motorista
            string Coluna2 = Convert.ToString(dados[2]);    //Kilometragem
            string Coluna3 = "";                            //distancia
            string Coluna4 = Convert.ToString(dados[3]);    //valor
            string Coluna5 = "";                            //indice

            if (distAnterior == 0) {distAnterior = Convert.ToInt32(Coluna2); }

            dist = Convert.ToInt32(Coluna2) - distAnterior;
            distAnterior = Convert.ToInt32(Coluna2);

            Coluna3 = dist.ToString();

            string stringcomaspas = "<tr>" +
                "<td>" + Coluna0 + "</td>" +
                "<td>" + Coluna1 + "</td>" +
                "<td style=\"text-align:right\">" + Coluna2 + "</td>" +
                "<td style=\"text-align:right\">" + Coluna3 + "</td>" +
                "<td style=\"text-align:right\">" + Coluna4 + "</td>" +
                "<td style=\"text-align:right\">" + Coluna5 + "</td>" +
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