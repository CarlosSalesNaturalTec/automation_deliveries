using System;
using System.Text;

public partial class Extras_Tabelas : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    int TotalRegistros = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            montaCabecalho();
            dadosCorpo();
            montaRodape();
            Literal1.Text = str.ToString();

            Literal_Quant.Text = TotalRegistros.ToString();
        }
    }

    private void montaCabecalho()
    {
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover \">" +
            "<thead>" +
            "<tr>" +
            "<th>ID</th>" +
            "<th>TABELA</th>" +
            "<th>1 HORA</th>" +
            "<th>2 HORAS</th>" +
            "<th>4 HORAS</th>" +
            "<th>6 HORAS</th>" +
            "<th>8 HORAS</th>" +
            "<th>DIÁRIA</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
        string stringselect = @"select ID_tabela , Nome, Semana_1Hora , Semana_2Horas,Semana_4Horas , Semana_6Horas , Semana_8Horas , Semana_Diaria " +
                " from Tbl_Extras_Precos" +
                " order by ID_tabela";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string linkUrl = "<a href=\"../Extras_Tabelas_Ficha.aspx?ID=" + Convert.ToString(dados[0]) + "\" target=\"_self\">";

            string Coluna1 = linkUrl + Convert.ToString(dados[0]) + "</a>";
            string Coluna2 = Convert.ToString(dados[1]);
            string Coluna3 = Convert.ToString(dados[2]);
            string Coluna4 = Convert.ToString(dados[3]);
            string Coluna5 = Convert.ToString(dados[4]);
            string Coluna6 = Convert.ToString(dados[5]);
            string Coluna7 = Convert.ToString(dados[6]);
            string Coluna8 = Convert.ToString(dados[7]);

            string stringcomaspas = "<tr>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna6 + "</td>" +
                "<td>" + Coluna7 + "</td>" +
                "<td>" + Coluna8 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);
            TotalRegistros++;
        }
        ConexaoBancoSQL.fecharConexao();
        
    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);
    }

}