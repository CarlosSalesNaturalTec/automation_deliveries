using System;
using System.Text;

public partial class Roteiros_Clientes1 : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        Preenche_Empresas();
        Preenche_Motoboys();
        Grid_Roteiros();
    }

    private void Preenche_Empresas()
    {
        string stringSelect = @"select ID_Cliente, Nome from Tbl_Clientes order by Nome";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);

        str.Clear();
        string scrNome = "<select class=\"form-control\" id=\"select_empresa\">";
        str.Append(scrNome);

        scrNome = "<option value=\"0\">Selecione um Cliente</option>";
        str.Append(scrNome);

        while (rcrdset.Read())
        {
            scrNome = "<option value=\"" + Convert.ToString(rcrdset[0]) + "\">" + Convert.ToString(rcrdset[1]) + "</option>";
            str.Append(scrNome);
        }
        ConexaoBancoSQL.fecharConexao();

        scrNome = "</select>";
        str.Append(scrNome);
        Literal_Empresa.Text = str.ToString();

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
        literal_mtoboy.Text = str.ToString();

    }

    private void Grid_Roteiros()
    {
        string stringSelect = "select ID_Entrega, Endereco, Bairro , Cidade, valor_Cliente " +
          " from Tbl_Entregas " +
          " where Status_Entrega = 'EM ABERTO'" +
          " order by Bairro, Endereco";
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

            ScriptDados = "<td>" + bt1 + Convert.ToString(rcrdsetUsers[1]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[2]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[3]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[4]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "</tr>";
            str.Append(ScriptDados);
        }
        ConexaoBancoSQL.fecharConexao();

        Literal_grid.Text = str.ToString();

    }

}