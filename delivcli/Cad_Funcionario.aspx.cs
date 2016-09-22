using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace delivcli
{
    public partial class Cad_Funcionario : Page
    {
        // Id do cliente
        string v_id_user = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            // tenta identificar se houve login. caso contrário vai para página de erro
            v_id_user = Session["Cli_ID"].ToString();

            if (!IsPostBack)
            {
               totalderegistros();
               atualiza_grid();
            }

        }

        public void totalderegistros()
        {
            // total de registros do item selecionado
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select("SELECT COUNT(*) AS totalderegistros FROM Tbl_Motoboys where ID_Cliente = " + v_id_user);
            String totalderegistros = "";
            try
            {
                while (dados.Read())
                {
                    totalderegistros = Convert.ToString(dados[0]);
                    lbl_total_motoboys.Text = totalderegistros;
                }
                ConexaoBancoSQL.fecharConexao();
            }
            catch (Exception)
            {
                lbl_total_motoboys.Text = "999";
                throw;
            }

        }

        public void atualiza_grid()
        {
            // listagem de funcionarios por cliente
            OperacaoBanco operacao = new OperacaoBanco();
            string stringSelect = "select * from Tbl_Motoboys where ID_Cliente = " + v_id_user + " order by Nome";
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
                bool inserir = operacao.Insert(@"INSERT INTO Tbl_Motoboys (ID_Cliente, Nome, Telefone, " +
                    "WhatsApp, Veiculo, Modelo, Placa, usuario, senha) VALUES (" + v_id_user +
                    ",'" + txt_nome.Text + "', '" + txt_telefone.Text +
                    "', '" + txt_whatsapp.Text + "', '" + txt_veiculo.Text + "', '" + txt_modelo.Text +
                    "', '" + txt_placa.Text + "', '" + txt_user.Text + "', '123456')");
                ConexaoBancoSQL.fecharConexao();

                txt_nome.Text = "";
                txt_telefone.Text = "";
                txt_whatsapp.Text = "";
                txt_veiculo.Text = "";
                txt_modelo.Text = "";
                txt_placa.Text = "";
                txt_user.Text = "";

                if (inserir == true)
                {
                    atualiza_grid();
                    totalderegistros();
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
                Boolean update = operacao.Update(@"UPDATE Tbl_Motoboys SET Nome='" + txt_edit_nome.Text + "', " +
                    "telefone = '" + txt_edit_telefone.Text + "', " +
                    "WhatsApp = '" + txt_edit_whatsapp.Text + "', Veiculo = '" + txt_edit_veiculo.Text + "', " +
                    "Modelo = '" + txt_edit_modelo.Text + "', Placa = '" + txt_edit_placa.Text + "', " +
                    "usuario = '" + txt_edit_user.Text + "' WHERE ID_Motoboy=" + lbl_id.Text + ";");
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
                Boolean deletar = operacao.Delete("delete from Tbl_Motoboys where ID_Motoboy =" + lbl_id.Text);
                ConexaoBancoSQL.fecharConexao();
                if (deletar == true)
                {
                    atualiza_grid();
                    totalderegistros();
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
            txt_edit_nome.Text = GridView2.SelectedRow.Cells[0].Text;
            txt_edit_telefone.Text = GridView2.SelectedRow.Cells[1].Text;
            txt_edit_whatsapp.Text = GridView2.SelectedRow.Cells[2].Text;
            txt_edit_veiculo.Text = GridView2.SelectedRow.Cells[3].Text;
            txt_edit_modelo.Text = GridView2.SelectedRow.Cells[4].Text;
            txt_edit_placa.Text = GridView2.SelectedRow.Cells[5].Text;
            txt_edit_user.Text = GridView2.SelectedRow.Cells[6].Text;
            lbl_id.Text = GridView2.SelectedRow.Cells[7].Text;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
}