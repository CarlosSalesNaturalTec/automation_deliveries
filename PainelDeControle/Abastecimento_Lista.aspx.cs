using System;
using System.Globalization;
using System.Text;

public partial class Abastecimento_Lista : System.Web.UI.Page
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
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover \">" +
            "<thead>" +
            "<tr>" +
            "<th>ID</th>" +
            "<th>PLACA</th>" +
            "<th>NOME</th>" +
            "<th>DATA</th>" +
            "<th>KM</th>" +
            "<th style=\"text-align:right\">VALOR</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
        string stringselect = @"select ID_Abastecimento, Placa , Nome, " +
                " format(DataAutoriza,'dd/MM/yyyy') as DataAbast, Kilometragem , Valor" +
                " from Tbl_Abastecimentos" +
                " order by DataAutoriza desc";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string linkUrl = "<a href=\"../Abastecimento_Ficha.aspx?IDAbast=" + Convert.ToString(dados[0]) + "\" target=\"_self\">";

            string Coluna1 = Convert.ToString(dados[1]);
            string Coluna2 = Convert.ToString(dados[2]);
            string Coluna3 = Convert.ToString(dados[3]);
            string Coluna4 = Convert.ToString(dados[4]);
            string Coluna5 = "";
            string Coluna6 = linkUrl + Convert.ToString(dados[0]) + "</a>";

            string valorSTR = Convert.ToString(dados[5]); //valor - auxiliar
            decimal valor = Convert.ToDecimal(valorSTR);
            Coluna5 = "<td style=\"text-align:right\"> <strong>" + valor.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR")) + "</strong></td>";

            string stringcomaspas = "<tr>" +
                "<td>" + Coluna6 + "</td>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                Coluna5 + 
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