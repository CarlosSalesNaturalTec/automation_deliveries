using System;
using System.Text;

public partial class Veiculos_Ficha : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        PreencheCampos(Request.QueryString["IDVeic"]);
        Literal1.Text = str.ToString();
    }

    private void PreencheCampos(string ID)
    {
        string ScriptDados = "";
        string stringSelect = "select Placa, Modelo " +
            "from Tbl_Veiculos " +
            "where ID_Veiculo = " + ID;
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('IDHidden').value = \"" + ID + "\";" +
                "document.getElementById('inputPlaca').value = \"" + Convert.ToString(rcrdset[0]) + "\";" +
                "document.getElementById('inputModelo').value = \"" + Convert.ToString(rcrdset[1]) + "\";" +
                "</script>";
        }
        ConexaoBancoSQL.fecharConexao();
        str.Clear();
        str.Append(ScriptDados);
    }
}