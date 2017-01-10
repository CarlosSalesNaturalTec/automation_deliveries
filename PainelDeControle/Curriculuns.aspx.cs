using System;
using System.Text;

public partial class Curriculuns : System.Web.UI.Page
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
        string stringcomaspas = "<table class=\"table table-striped table-hover \">" +
            "<thead>" +
            "<tr>" +
            "<th>NOME</th>" +
            "<th>CELULAR</th>" +
            "<th>TELEFONE</th>" +
            "<th>VEICULO</th>" +
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
        string stringselect = @"select Nome, TelCelular, TelResid , AnoModelo, ID_Curric " +
                " from Tbl_Curriculum " +
                " order by Nome";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string linkUrl = "<a href=\"CurriculumFicha.aspx?IDCli=" + Convert.ToString(dados[4]) + "\" target=\"_self\">";

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