using System;
using System.Text;

public partial class Orcamento_lista : System.Web.UI.Page
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
        string stringcomaspas = "<table id=\"tabelaOrc\" class=\"table table-striped table-hover \">" +
            "<thead>" +
            "<tr>" +
            "<th>ID</th>" +
            "<th>EMPRESA</th>" +
            "<th>CONTATO</th>" +
            "<th>NECESSIDADE</th>" +
            "<th>DISPONIB.</th>" +
            "<th>DATA SOLIC.</th>" +
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
        string stringselect = @"select ID_Solicitacao, Empresa, Contato, Telefone, Necessidade, Disponibilidade," +
                " format(Data_Solicitacao,'dd/MM/yyyy') as DataOrc, StatusORC  " +
                " from Tbl_Orcamentos" +
                " order by ID_Solicitacao desc";
        int TotalRegistros = 0;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string linkUrl = "<a href=\"../Orcamento_Ficha.aspx?IDorc=" + Convert.ToString(dados[0]) + "\" target=\"_self\">";

            string Coluna0 = Convert.ToString(dados[0]);
            string Coluna1 = linkUrl + Convert.ToString(dados[1]) + "</a>";
            string Coluna2 = Convert.ToString(dados[2]);
            string Coluna3 = Convert.ToString(dados[3]);
            string Coluna4 = Convert.ToString(dados[4]);
            string Coluna5 = Convert.ToString(dados[5]);
            string Coluna6 = Convert.ToString(dados[6]);
            string Coluna7 = Convert.ToString(dados[7]);

            string stringcomaspas = "<tr>" +
                "<td>" + Coluna0 + "</td>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna6 + "</td>" +
                "<td>" + Coluna7 + "</td>" +
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