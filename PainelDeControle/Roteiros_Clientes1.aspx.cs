using System;
using System.Text;

public partial class Roteiros_Clientes1 : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        Preenche_Empresas();
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
}