using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace deliv
{
    public partial class _Default : Page
    {
        StringBuilder str = new StringBuilder();

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
            string stringSelect = "select ID_Motoboy, usuario , senha from Tbl_Motoboys where usuario = '" + inputUser.Text + "'";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
            while (rcrdset.Read())
            {
                if (inputSenha.Text == Convert.ToString(rcrdset[2]))
                {
                    Session["Func_ID"] = Convert.ToString(rcrdset[0]);
                    Response.Redirect("Realizar.aspx");
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