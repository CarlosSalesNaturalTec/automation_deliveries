using System;
using System.Text;

public partial class ClienteFicha : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        PreencheCampos(Request.QueryString["IDCli"]);
        Literal1.Text = str.ToString();

        CidadesLista(Request.QueryString["IDCli"]);
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

    private void CidadesLista(string ID)
    {
        string stringSelect = "select ID_Cidade, Cidade , Valor " +
            " from Tbl_Clientes_Cidade_Custos  " +
            " where ID_Cliente  = " + ID +
            " order by Cidade ";
        OperacaoBanco operacaoUsers = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdsetUsers = operacaoUsers.Select(stringSelect);

        str.Clear();
        string ScriptDados;

        while (rcrdsetUsers.Read())
        {
            string bt1 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='CidadeExcluir(this," +
                Convert.ToString(rcrdsetUsers[0]) +
                ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";

            ScriptDados = "<tr>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + bt1 + Convert.ToString(rcrdsetUsers[1]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[2]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "</tr>";
            str.Append(ScriptDados);
        }
        ConexaoBancoSQL.fecharConexao();

        Literal2.Text = str.ToString();

    }
}