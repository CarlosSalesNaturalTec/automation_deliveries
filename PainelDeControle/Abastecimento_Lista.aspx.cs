using System;
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
            "<th>PLACA</th>" +
            "<th>NOME</th>" +
            "<th>VALOR</th>" +
            "<th>DATA</th>" +
            "<th>ID</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
        string stringselect = @"select ID_Abastecimento, Placa , Nome, Valor," +
                " format(DataAutoriza,'dd/MM/yyyy') as DataAbast" +
                " from Tbl_Abastecimentos" +
                " order by DataAutoriza desc";
        int TotalRegistros = 0;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string linkUrl = "<a href=\"../Abastecimento_Ficha.aspx?IDAbast=" + Convert.ToString(dados[0]) + "\" target=\"_self\">";

            string Coluna1 = linkUrl + Convert.ToString(dados[1]) + "</a>";
            string Coluna2 = Convert.ToString(dados[2]);
            string Coluna3 = Convert.ToString(dados[3]);
            string Coluna4 = Convert.ToString(dados[4]);
            string Coluna0 = Convert.ToString(dados[0]);

            string stringcomaspas = "<tr>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna0 + "</td>" +
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