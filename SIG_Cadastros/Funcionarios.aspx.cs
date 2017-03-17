using System;
using System.Text;

public partial class Funcionarios : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    int TotaldeRegistros = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            COntadorRegistros();
            Literal_Quant.Text = TotaldeRegistros.ToString();
        }
    }

    private void COntadorRegistros()
    {
        string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
        string stringselect = @"select ID_Motoboy from Tbl_Motoboys";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            TotaldeRegistros++;
        }
        ConexaoBancoSQL.fecharConexao();
    }

}