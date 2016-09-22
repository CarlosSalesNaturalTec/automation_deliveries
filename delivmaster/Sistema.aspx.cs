using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace delivmaster
{
    public partial class Sistema : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // tenta identificar se houve login. caso contrário vai para página de erro
            string v_id_user = Session["ID_User"].ToString();

            try
            {
               total_registros();
               atualiza_grid();
            }
            catch {
            }
        }

        public void total_registros()
        {
            // total de Usuários cadastrados
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select("SELECT COUNT(*) AS totalderegistros FROM Tbl_Usuarios;");
            string totalderegistros = "";
            while (dados.Read())
            {
                totalderegistros = Convert.ToString(dados[0]);
                lbl_total_usuarios.Text = totalderegistros;
            }
            ConexaoBancoSQL.fecharConexao();
        }

        public void atualiza_grid()
        {
            // listagem de Usuarios
            OperacaoBanco operacao = new OperacaoBanco();
            string stringSelect = "select * from Tbl_Usuarios order by Usuario";
            System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
            GridView2.DataSource = rcrdset;
            GridView2.DataBind();
            ConexaoBancoSQL.fecharConexao();
        }

        protected void bt_novo_salvar_click(object sender, EventArgs e)
        {
            try
            {   
                OperacaoBanco operacao = new OperacaoBanco();
                Boolean inserir = operacao.Insert(@"INSERT INTO Tbl_Usuarios (usuario , nivel, senha) " +
                    "VALUES ('"+ txt_user.Text + "', '" + txt_nivel.Text + "', '" + txt_senha.Text + "');");
                ConexaoBancoSQL.fecharConexao();

                txt_user.Text = "";
                txt_senha.Text = "";

                if (inserir == true)
                {
                    total_registros();
                    atualiza_grid();
                }
            }
            catch
            {
            }
        }

        protected void bt_editar_salvar_click(object sender, EventArgs e)
        {
            try
            {
                OperacaoBanco operacao = new OperacaoBanco();
                Boolean update = operacao.Update("UPDATE Tbl_Usuarios SET Usuario='" + txt_edit_user.Text + "', nivel='" + 
                    txt_edit_nivel.Text + "', senha = '" + txt_edit_senha.Text + "' WHERE ID_user = " + lbl_edit_id.Text);
                ConexaoBancoSQL.fecharConexao();
                if (update == true)
                {
                    atualiza_grid();
                }
            }
            catch
            {
            }
        }

        protected void bt_excluir_click(object sender, EventArgs e)
        {
            try
            {
                OperacaoBanco operacao = new OperacaoBanco();
                Boolean deletar = operacao.Delete("delete from Tbl_Usuarios where ID_user =" + lbl_edit_id.Text);
                ConexaoBancoSQL.fecharConexao();
                if (deletar == true)
                {
                    total_registros();
                    atualiza_grid();
                }
            }
            catch
            {
            }
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //muda o ponteiro do mouse
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {

            //modal edit delete  - preenche campos
            txt_edit_user.Text = GridView2.SelectedRow.Cells[0].Text;
            txt_edit_nivel.Text = GridView2.SelectedRow.Cells[1].Text;
            lbl_edit_id.Text = GridView2.SelectedRow.Cells[2].Text;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
}