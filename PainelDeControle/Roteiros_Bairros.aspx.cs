using System;
using System.Text;

public partial class Roteiros_Bairros : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        Preenche_Motoboys();
        Grid_Roteiros();
    }

    private void Preenche_Motoboys()
    {
        string stringSelect = "select ID_Motoboy , Nome from Tbl_Motoboys order by Nome";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);

        str.Clear();
        string scrNome = "<select class=\"form-control\" id=\"select_motoboy\">";
        str.Append(scrNome);

        scrNome = "<option value=\"0\">Selecione um Motoboy</option>";
        str.Append(scrNome);

        while (rcrdset.Read())
        {
            scrNome = "<option value=\"" + Convert.ToString(rcrdset[0]) + "\">" + Convert.ToString(rcrdset[1]) + "</option>";
            str.Append(scrNome);
        }
        ConexaoBancoSQL.fecharConexao();

        scrNome = "</select>";
        str.Append(scrNome);
        Literal_Motoboy.Text = str.ToString();

    }

    private void Grid_Roteiros()
    {
        string stringSelect = "select Bairro , Count(Bairro) as quantB " +
          " from Tbl_Entregas " +
          " where Status_Entrega = 'EM ABERTO'" +
          " group by Bairro";
        OperacaoBanco operacaoUsers = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdsetUsers = operacaoUsers.Select(stringSelect);

        str.Clear();
        string ScriptDados;

        while (rcrdsetUsers.Read())
        {
            string bt1 = "<input type='checkbox'class='w3-check' name='chkselecao' value='" +
                Convert.ToString(rcrdsetUsers[0]) +
                "' />&nbsp;&nbsp;&nbsp;";

            ScriptDados = "<tr>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + bt1 + Convert.ToString(rcrdsetUsers[0]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[1]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "</tr>";
            str.Append(ScriptDados);
        }
        ConexaoBancoSQL.fecharConexao();

        Literal_grid.Text = str.ToString();

    }

}