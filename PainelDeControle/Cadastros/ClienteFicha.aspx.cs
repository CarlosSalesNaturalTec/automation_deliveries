using System;
using System.Text;

public partial class ClienteFicha : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        PreencheCampos(Request.QueryString["IDCli"]);
        Literal1.Text = str.ToString();
    }

    private void PreencheCampos(string ID)
    {
        string ScriptDados = "";
        string stringSelect = @"select Nome, Responsavel , email, Telefone, Usuario, Senha " +
            "from Tbl_Clientes  " +
            "where ID_Cliente  = " + ID;
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('IDHidden').value = \"" + ID + "\";" +
                "document.getElementById('inputNome').value = \"" + Convert.ToString(rcrdset[0]) + "\";" +
                "document.getElementById('inputResponsavel').value = \"" + Convert.ToString(rcrdset[1]) + "\";" +
                "document.getElementById('inputEmail').value = \"" + Convert.ToString(rcrdset[2]) + "\";" +
                "document.getElementById('inputTelefone').value = \"" + Convert.ToString(rcrdset[3]) + "\";" +
                "document.getElementById('inputUsuario').value = \"" + Convert.ToString(rcrdset[4]) + "\";" +
                "document.getElementById('inputSenha').value = \"" + Convert.ToString(rcrdset[5]) + "\";" +
                "</script>";
        }
        ConexaoBancoSQL.fecharConexao();
        str.Clear();
        str.Append(ScriptDados);
    }
}