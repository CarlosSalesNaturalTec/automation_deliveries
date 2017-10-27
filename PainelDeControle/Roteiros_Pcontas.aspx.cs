using System;
using System.Globalization;
using System.Text;

public partial class Roteiros_Pcontas : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        Grid_Realizadas();
    }

    private void Grid_Realizadas()
    {

        string stringselect = "select Tbl_Motoboys.ID_Motoboy, Tbl_Motoboys.Nome, count(Tbl_Entregas.ID_Entrega) as quant1 " +
                "from Tbl_Entregas " +
                "inner join Tbl_Motoboys on Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy " +
                "where Tbl_Entregas.Pcontas = 0 and Status_Entrega <> 'EM ABERTO' " +
                "group by Tbl_Motoboys.ID_Motoboy, Tbl_Motoboys.Nome ";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            
            string Coluna1 = "<a href = \"Roteiros_Pcontas_Indiv.aspx?p1=" + Convert.ToString(dados[0]) + 
                "&p2=" + Convert.ToString(dados[1]) +
                "\">" + Convert.ToString(dados[1]) + "</a>";

            string Coluna2 = Convert.ToString(dados[2]);

            string stringcomaspas = "<tr>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);
        }
        ConexaoBancoSQL.fecharConexao();

        Literal_grid1.Text = str.ToString();

    }

}