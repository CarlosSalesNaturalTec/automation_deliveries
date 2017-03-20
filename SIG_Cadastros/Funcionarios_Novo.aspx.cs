using System;
using System.Text;

public partial class Funcionarios_Novo : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Combo_Clientes();
        }
    }

    private void Combo_Clientes()
    {
        string stringselect = "select Nome, ID_CLiente from Tbl_Clientes order by Nome";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        str.Clear();
        string dadosCLiente;

        dadosCLiente = "<option selected value=\"0\">Selecione</option>";
        str.Append(dadosCLiente);

        while (dados.Read())
        {
            dadosCLiente = "<option value=\"" + Convert.ToString(dados[1]) + "\">" + Convert.ToString(dados[0]) + "</option>";
            str.Append(dadosCLiente);   
        }
        ConexaoBancoSQL.fecharConexao();
        literal_clientes.Text = str.ToString();
    }

}