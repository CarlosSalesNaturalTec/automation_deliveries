using System;
using System.Web.UI;

namespace delivcli
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                inputUser.Focus();
            }
        }

        protected void bt_conectar_Click(object sender, EventArgs e)
        {
            // localiza usuario
            string stringSelect = "select ID_Cliente , usuario , senha from Tbl_Clientes where usuario = '" + inputUser.Text + "'";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
            while (rcrdset.Read())
            {
                if (inputSenha.Text == Convert.ToString(rcrdset[2]))
                {
                    Session["Cli_ID"] = Convert.ToString(rcrdset[0]);
                    Response.Redirect("Painel.aspx");
                }
                else
                {
                    lbl_msg.Text = "USUÁRIO OU SENHA INVÁLIDOS";
                }
            }
            ConexaoBancoSQL.fecharConexao();
        }
    }
}