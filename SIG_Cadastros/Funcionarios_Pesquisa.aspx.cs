using System;
using System.Text;

public partial class Funcionarios : System.Web.UI.Page
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
            "<th>NOME</th>" +
            "<th>VEICULO</th>" +
            "<th>PLACA</th>" +
            "<th>CLIENTE</th>" +
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
        string stringselect = "select Tbl_Motoboys.Nome as NomeEnt, Tbl_Motoboys.Veiculo, Tbl_Motoboys.Placa, Tbl_Clientes.Nome as NomeCli, Tbl_Motoboys.ID_Motoboy " +
                " from Tbl_Motoboys " +
                " INNER JOIN Tbl_Clientes ON Tbl_Motoboys.ID_Cliente  = Tbl_Clientes.ID_Cliente " +
                " order by Tbl_Motoboys.Nome";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string linkUrl = "<a href=\"Funcionarios_Ficha.aspx?p1=" + Convert.ToString(dados[4]) + "\" target=\"_self\">";

            string Coluna1 = linkUrl + Convert.ToString(dados[0]) + "</a>";
            string Coluna2 = Convert.ToString(dados[1]);
            string Coluna3 = Convert.ToString(dados[2]);
            string Coluna4 = Convert.ToString(dados[3]);
            string Coluna5 = Convert.ToString(dados[4]);

            string stringcomaspas = "<tr>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
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