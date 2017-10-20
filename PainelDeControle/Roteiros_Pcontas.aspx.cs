using System;
using System.Globalization;
using System.Text;

public partial class Roteiros_Pcontas : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        Grid_Realizadas();
        Grid_Nao_realizadas();
    }

    private void Grid_Realizadas()
    {
        // <!--*******Customização*******-->
        string stringselect = "select Tbl_Motoboys.Nome , count(Tbl_Entregas.ID_Entrega) as quant1, sum(Tbl_Entregas.valor_Cliente) as valor1 " +
                "from Tbl_Entregas " +
                "inner join Tbl_Motoboys on Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy " +
                "where Tbl_Entregas.Status_Entrega = 'ENTREGA REALIZADA' and Tbl_Entregas.Pcontas = 0 " +
                "group by Tbl_Motoboys.Nome ";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            // <!--*******Customização*******-->
            string Coluna1 = Convert.ToString(dados[0]);
            string Coluna2 = Convert.ToString(dados[1]);

            decimal valor = Convert.ToDecimal(dados[2]);
            string Coluna3 = "R$ " + valor.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));

            string bt1 = "<input type='checkbox'class='w3-check' name='chkselecao' value='" +
                Convert.ToString(dados[0]) +
                "' />&nbsp;&nbsp;&nbsp;";

            // <!--*******Customização*******-->
            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);
        }
        ConexaoBancoSQL.fecharConexao();

        Literal_grid1.Text = str.ToString();

    }

    private void Grid_Nao_realizadas()
    {
        // <!--*******Customização*******-->
        string stringselect = "select Tbl_Motoboys.Nome , count(Tbl_Entregas.ID_Entrega) as quant1, sum(Tbl_Entregas.valor_Cliente) as valor1 " +
                "from Tbl_Entregas " +
                "inner join Tbl_Motoboys on Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy " +
                "where Tbl_Entregas.Status_Entrega <> 'ENTREGA REALIZADA' and Tbl_Entregas.Pcontas = 0 " +
                "group by Tbl_Motoboys.Nome ";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            // <!--*******Customização*******-->
            string Coluna1 = Convert.ToString(dados[0]);
            string Coluna2 = Convert.ToString(dados[1]);

            decimal valor = Convert.ToDecimal(dados[2]);
            string Coluna3 = "R$ " + valor.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));

            string bt1 = "<input type='checkbox'class='w3-check' name='chkselecao' value='" +
                Convert.ToString(dados[0]) +
                "' />&nbsp;&nbsp;&nbsp;";

            // <!--*******Customização*******-->
            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);
        }
        ConexaoBancoSQL.fecharConexao();

        Literal_grid1.Text = str.ToString();

    }

}